using csdmc1c80;
using Project.DLL;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Project.UI
{
    public partial class MotionForm : Form
    {
        private readonly Axis axis = new Axis();
        private readonly int cardIndex;
        private readonly ushort cardNo;

        public MotionForm(int cardIndex)
        {
            this.cardIndex = cardIndex;
            this.cardNo = CardAxis.ToCardNo(cardIndex);
            InitializeComponent();
            Text = "运动控制 - 卡" + cardNo;
            Axis.Minimum = 0;
            Axis.Maximum = CardAxis.AxesPerCard - 1;
            Axis.Value = 0;
            label3.Text = string.Empty;
            timer1.Start();
        }

        private ushort GetLocalAxisFromUI()
        {
            return (ushort)Axis.Value;
        }

        private ushort GetGlobalAxisFromUI()
        {
            return CardAxis.ToGlobalAxis(cardIndex, GetLocalAxisFromUI());
        }

        private void ReadParamsFromUI()
        {
            axis.AxisNumber = GetGlobalAxisFromUI();
            axis.MinVel = double.Parse(Start_speed.Text);
            axis.MaxVel = double.Parse(Max_speed.Text);
            axis.Tac = double.Parse(Tacc.Text);
            axis.Distance = int.Parse(Dist_pos.Text);
            axis.STac = double.Parse(S_Tacc.Text);
            axis.Direction = CW.Checked ? 1 : -1;
            axis.MotionMode = T_Type.Checked ? 0 : 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ReadParamsFromUI();

                int sendDist = axis.Direction * axis.Distance;
                label3.Text = string.Format(
                    "将发送: 本卡轴={0} 全局轴={1} 方向={2} 距离={3} 实际dist={4} 模式={5}",
                    GetLocalAxisFromUI(), axis.AxisNumber, axis.Direction, axis.Distance, sendDist,
                    axis.MotionMode == 0 ? "T" : "S");

                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        string log = RunDirectionDiagnostic(axis.AxisNumber, axis.Distance);
                        try
                        {
                            BeginInvoke((Action)(() => MessageBox.Show(log, "方向诊断结果")));
                        }
                        catch
                        {
                        }
                    });
                    return;
                }

                bool ok = AxisDLL.MoveAbsolute(axis);
                MessageBox.Show(ok ? "运动指令发送成功" : "运动指令发送失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式错误或异常：" + ex.Message);
            }
        }

        private bool WaitForStop(ushort axisNo, int timeoutMs)
        {
            int waited = 0;
            const double speedEpsilon = 1e-6;

            try
            {
                while (waited < timeoutMs)
                {
                    try
                    {
                        double spd = dmc1c80.d1c80_read_current_speed(axisNo);
                        if (Math.Abs(spd) < speedEpsilon) return true;
                    }
                    catch (Exception ex)
                    {
                        if (ex is DllNotFoundException || ex is EntryPointNotFoundException || ex is MissingMethodException)
                            goto PositionFallback;
                    }

                    Thread.Sleep(50);
                    waited += 50;
                }

                return false;
            }
            catch
            {
            }

        PositionFallback:
            try
            {
                const int stableThreshold = 3;
                int stableCount = 0;
                int lastPos = dmc1c80.d1c80_get_position(axisNo);

                while (waited < timeoutMs)
                {
                    Thread.Sleep(100);
                    waited += 100;

                    int pos = dmc1c80.d1c80_get_position(axisNo);
                    if (pos == lastPos)
                    {
                        stableCount++;
                        if (stableCount >= stableThreshold) return true;
                    }
                    else
                    {
                        stableCount = 0;
                        lastPos = pos;
                    }
                }
            }
            catch
            {
            }

            return false;
        }

        private string RunDirectionDiagnostic(ushort axisNo, int distance)
        {
            var sb = new StringBuilder();
            try
            {
                int pos0 = dmc1c80.d1c80_get_position(axisNo);
                sb.AppendLine("起始位置: " + pos0);

                sb.AppendLine("发送 +" + distance + " 到全局轴 " + axisNo);
                dmc1c80.d1c80_pmove(axisNo, distance, 0);
                WaitForStop(axisNo, 8000);
                int pos1 = dmc1c80.d1c80_get_position(axisNo);
                sb.AppendLine("正向后位置: " + pos1 + "  增量: " + (pos1 - pos0));

                Thread.Sleep(200);

                sb.AppendLine("发送 -" + distance + " 到全局轴 " + axisNo);
                dmc1c80.d1c80_pmove(axisNo, -distance, 0);
                WaitForStop(axisNo, 8000);
                int pos2 = dmc1c80.d1c80_get_position(axisNo);
                sb.AppendLine("反向后位置: " + pos2 + "  增量: " + (pos2 - pos1));

                if (pos1 - pos0 > 0 && pos2 - pos1 < 0)
                    sb.AppendLine("结论：正负脉冲映射正常（正为增加，负为减少）。");
                else if (pos1 - pos0 > 0 && pos2 - pos1 > 0)
                    sb.AppendLine("结论：两次移动方向相同，请检查控制器文档或 pulse/dir 模式。");
                else if (pos1 - pos0 < 0 && pos2 - pos1 > 0)
                    sb.AppendLine("结论：正/负被颠倒，可在软件中反转方向或调整驱动设置。");
                else
                    sb.AppendLine("结论：异常结果，请检查硬件/驱动和接线。");
            }
            catch (Exception ex)
            {
                sb.AppendLine("诊断异常: " + ex.Message);
            }

            return sb.ToString();
        }

        private void CW_CheckedChanged(object sender, EventArgs e)
        {
            axis.Direction = 1;
        }

        private void CCW_CheckedChanged(object sender, EventArgs e)
        {
            axis.Direction = -1;
        }

        private void T_Type_CheckedChanged(object sender, EventArgs e)
        {
            axis.MotionMode = 0;
        }

        private void S_Type_CheckedChanged(object sender, EventArgs e)
        {
            axis.MotionMode = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dmc1c80.d1c80_emg_stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("急停失败：" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ReadParamsFromUI();
                dmc1c80.d1c80_decel_stop(axis.AxisNumber, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("减速停失败：" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                ReadParamsFromUI();
                dmc1c80.d1c80_set_position(axis.AxisNumber, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("位置清零失败：" + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ushort globalAxis = GetGlobalAxisFromUI();
                label3.Text = "本卡轴" + GetLocalAxisFromUI()
                    + "  运行速度：" + dmc1c80.d1c80_read_current_speed(globalAxis)
                    + "  当前位置：" + dmc1c80.d1c80_get_position(globalAxis);
            }
            catch
            {
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer1.Stop();
            base.OnFormClosing(e);
        }
    }
}
