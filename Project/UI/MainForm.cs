using csdmc1c80;
using Project.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project
{
    public partial class MainForm : Form
    {
        private int selectedCardIndex = -1;
        private Panel selectedCardPanel = null;
        private List<bool> cardConnected = new List<bool>();
        private bool boardInitialized = false;
        private bool hardwareAvailable = false;
        private int cardCount = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        // 断开/重新连接 按钮（button1）
        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedCardIndex < 0 || selectedCardPanel == null)
            {
                MessageBox.Show("请先选择一个控制卡。");
                return;
            }

            if (selectedCardIndex >= cardConnected.Count)
            {
                MessageBox.Show("所选卡索引超出范围。");
                return;
            }

            // 当前是已连接 -> 执行断开操作
            if (cardConnected[selectedCardIndex])
            {
                if (hardwareAvailable)
                {
                    try
                    {
                        dmc1c80.d1c80_board_reset((ushort)selectedCardIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("硬件断开失败：" + ex.Message);
                        return;
                    }
                }

                cardConnected[selectedCardIndex] = false;

                // 更新该卡面板图片为断开图 Card1
                var pb = selectedCardPanel.Controls.OfType<PictureBox>().FirstOrDefault();
                if (pb != null)
                {
                    try
                    {
                        pb.Image = Properties.Resources.Card1;
                    }
                    catch
                    {
                        pb.Image = null;
                        pb.BackColor = Color.LightGray;
                    }
                }

                // 修改主断开按钮为“重新连接”样式
                try
                {
                    button1.Image = Properties.Resources.Connect;
                }
                catch
                {
                    // 保持原样
                }
                button1.Text = "重新连接";

                MessageBox.Show("已断开 DMC1C80-" + GetCardNo(selectedCardIndex) + "。");
            }
            else
            {
                cardConnected[selectedCardIndex] = true;

                // 恢复该卡面板图片为连接图 Card
                var pb = selectedCardPanel.Controls.OfType<PictureBox>().FirstOrDefault();
                if (pb != null)
                {
                    try
                    {
                        pb.Image = Properties.Resources.Card;
                    }
                    catch
                    {
                        pb.Image = null;
                        pb.BackColor = Color.LightGray;
                    }
                }

                // 恢复主断开按钮为“断开连接”样式
                try
                {
                    // 资源里有中文名的断开连接图标
                    button1.Image = Properties.Resources.断开连接;
                }
                catch
                {
                    // 兜底：不改图片
                }
                button1.Text = "断开连接";

                MessageBox.Show("已重新连接 DMC1C80-" + GetCardNo(selectedCardIndex) + "。");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index;
            if (!EnsureCardSelected(out index))
                return;

            IOForm iOForm = new IOForm(GetCardNo(index));
            iOForm.Text = "运动状态 - 卡" + GetCardNo(index);
            iOForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index;
            if (!EnsureCardSelected(out index))
                return;

            MotionForm motionForm = new MotionForm(index);
            motionForm.Show();
        }

        private bool EnsureCardSelected(out int cardIndex)
        {
            cardIndex = selectedCardIndex;

            if (selectedCardIndex < 0)
            {
                MessageBox.Show("请先选择一个控制卡。");
                return false;
            }

            if (selectedCardIndex < cardConnected.Count && !cardConnected[selectedCardIndex])
            {
                MessageBox.Show("该卡已断开，无法操作。");
                return false;
            }

            return true;
        }

        private static ushort GetCardNo(int cardIndex)
        {
            return CardAxis.ToCardNo(cardIndex);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            init();
        }

        public void init()
        {
            try
            {
                if (!boardInitialized)
                {
                    try
                    {
                        cardCount = dmc1c80.d1c80_board_init();
                        if (cardCount > 0)
                        {
                            boardInitialized = true;
                            hardwareAvailable = true;
                        }
                        else
                        {
                            hardwareAvailable = true;
                            MessageBox.Show("未找到控制卡！请检查驱动、dmc1c80.dll 是否与 exe 同目录。");
                            return;
                        }
                    }
                    catch (DllNotFoundException)
                    {
                        cardCount = 4;
                        hardwareAvailable = false;
                    }
                    catch (EntryPointNotFoundException)
                    {
                        cardCount = 4;
                        hardwareAvailable = false;
                    }
                    catch (BadImageFormatException)
                    {
                        cardCount = 4;
                        hardwareAvailable = false;
                        MessageBox.Show(
                            "无法加载 dmc1c80.dll（位数不匹配 0x8007000B）。\r\n\r\n" +
                            "exe 与 dll 必须同为 64 位或同为 32 位。\r\n" +
                            "在 64 位 Windows 上请使用 Any CPU 编译，并复制 SDK 里 x64 目录下的 dmc1c80.dll。\r\n\r\n" +
                            "当前将进入模拟模式（显示 4 张卡）。",
                            "DLL 加载提示",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("板卡初始化失败：" + ex.Message);
                        return;
                    }
                }

                if (cardCount <= 0)
                {
                    MessageBox.Show("未找到控制卡！");
                    return;
                }

                if (hardwareAvailable)
                {
                    try
                    {
                        dmc1c80.d1c80_get_lib_version();
                    }
                    catch
                    {
                        // 读版本失败不影响后续使用
                    }
                    MessageBox.Show("初始化成功！找到控制卡数量：" + cardCount);
                }
                else
                {
                    MessageBox.Show("模拟模式（未检测到硬件），显示 " + cardCount + " 张卡。");
                }

                CreateCardControls(cardCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("界面初始化异常：" + ex.Message);
            }
        }

        /// <summary>
        /// 在 panel1 下生成若干卡显示控件，每个为一个小 Panel，包含上方名称和下方 PictureBox。
        /// 第一个控件显示为 DMC1C80-0，卡号与 API 均为 0 起算。
        /// </summary>
        /// <param name="cardCount"></param>
        private void CreateCardControls(int cardCount)
        {
            if (cardCount <= 0) return;

            // 取消之前的选择
            selectedCardIndex = -1;
            selectedCardPanel = null;
            cardConnected.Clear();

            // 保留 panel1 内的 label1（状态说明），移除其它运行时添加的控件
            List<Control> toRemove = new List<Control>();
            foreach (Control c in panel1.Controls)
            {
                if (c != label1)
                    toRemove.Add(c);
            }
            foreach (var c in toRemove)
                panel1.Controls.Remove(c);

            int cardWidth = 150;
            int cardHeight = 160;
            int margin = 8;
            int startX = 10;
            int startY = 10;

            for (int i = 0; i < cardCount; i++)
            {
                string cardName = "DMC1C80-" + i;

                Panel cardPanel = new Panel();
                cardPanel.Name = cardName;
                cardPanel.Size = new Size(cardWidth, cardHeight);
                cardPanel.BorderStyle = BorderStyle.FixedSingle;
                cardPanel.Location = new Point(startX + i * (cardWidth + margin), startY);
                cardPanel.Tag = i; // 存索引，便于识别

                // 名称标签（置顶并水平居中）
                Label lbl = new Label();
                lbl.Name = cardName + "_Label";
                lbl.Text = cardName;
                lbl.AutoSize = true;
                Size textSize = TextRenderer.MeasureText(lbl.Text, lbl.Font);
                lbl.Location = new Point((cardWidth - textSize.Width) / 2, 6);

                // 图片框（置于标签下方并水平居中）
                PictureBox pb = new PictureBox();
                pb.Name = cardName + "_Picture";
                pb.Size = new Size(96, 96);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                int pbY = lbl.Location.Y + textSize.Height + 6;
                pb.Location = new Point((cardWidth - pb.Width) / 2, pbY);

                // 初始化：卡默认已连接，使用 Resources.Card
                cardConnected.Add(true);
                try
                {
                    pb.Image = Properties.Resources.Card;
                }
                catch
                {
                    pb.BackColor = Color.LightGray;
                }

                // 绑定点击事件，点击任意部位都选中该卡
                cardPanel.Click += Card_Click;
                lbl.Click += Card_Click;
                pb.Click += Card_Click;

                cardPanel.Controls.Add(lbl);
                cardPanel.Controls.Add(pb);

                panel1.Controls.Add(cardPanel);
            }

            // 把状态说明 label 放到最下方并置顶显示
            label1.Location = new Point(14, Math.Max(panel1.Height - label1.Height - 6, startY + cardHeight + 4));
            label1.BringToFront();

            // 按钮保持可用（不禁用）
            button4.Enabled = true;
            button5.Enabled = true;

            // 默认主断开按钮文字/图标为“断开连接”
            try
            {
                button1.Image = Properties.Resources.断开连接;
            }
            catch { }
            button1.Text = "断开连接";
        }

        // 点击卡片统一处理（添加到类中）
        private void Card_Click(object sender, EventArgs e)
        {
            Control clicked = sender as Control;
            Panel panel = null;

            if (clicked is Panel)
                panel = (Panel)clicked;
            else if (clicked.Parent is Panel)
                panel = (Panel)clicked.Parent;

            if (panel == null) return;
            if (!(panel.Tag is int)) return;

            int idx = (int)panel.Tag;
            SelectCard(idx, panel);
        }

        // 设置选中视觉与索引，并根据选中卡状态更新 button1 文本/图片
        private void SelectCard(int index, Panel panel)
        {
            if (selectedCardPanel != null && selectedCardPanel != panel)
            {
                // 恢复之前面板外观
                selectedCardPanel.BackColor = SystemColors.Control;
            }

            selectedCardIndex = index;
            selectedCardPanel = panel;

            // 高亮当前选中（修改为你喜欢的样式）
            selectedCardPanel.BackColor = Color.LightSteelBlue;

            // 根据所选卡的连接状态调整主断开按钮外观和文字
            bool connected = true;
            if (index < cardConnected.Count)
                connected = cardConnected[index];

            if (connected)
            {
                try
                {
                    button1.Image = Properties.Resources.断开连接;
                }
                catch { }
                button1.Text = "断开连接";
            }
            else
            {
                try
                {
                    button1.Image = Properties.Resources.Connect;
                }
                catch { }
                button1.Text = "重新连接";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (boardInitialized && hardwareAvailable)
            {
                try
                {
                    dmc1c80.d1c80_board_close();
                }
                catch
                {
                }
                boardInitialized = false;
                cardCount = 0;
            }

            init();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (boardInitialized && hardwareAvailable)
            {
                try
                {
                    dmc1c80.d1c80_board_close();
                }
                catch
                {
                }
                boardInitialized = false;
            }

            base.OnFormClosing(e);
        }
    }
}
