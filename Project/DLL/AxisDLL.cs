using csdmc1c80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.DLL
{
    internal class AxisDLL
    {
        // 绝对定位运动（带返回值，告诉你成功失败）
        public static bool MoveAbsolute(Axis axis)
        {
            if (axis == null) return false;

            // 基础配置
            dmc1c80.d1c80_set_pulse_outmode(axis.AxisNumber, 0);

            // T 曲线
            if (axis.MotionMode == 0)
            {
                dmc1c80.d1c80_set_profile(
                    axis.AxisNumber,
                    axis.MinVel,
                    axis.MaxVel,
                    axis.Tac,
                    axis.Tac
                );
            }
            // S 曲线
            else
            {
                dmc1c80.d1c80_set_profile(
                    axis.AxisNumber,
                    axis.MinVel,
                    axis.MaxVel,
                    axis.Tac,
                    axis.Tac
                );
                dmc1c80.d1c80_set_s_profile(axis.AxisNumber, axis.STac);
            }

            // 发送运动指令
            int dist = axis.Direction * axis.Distance;
            uint ret = dmc1c80.d1c80_pmove(axis.AxisNumber, dist, 0);

            return ret == 0; // 0=成功
        }
    }
}
