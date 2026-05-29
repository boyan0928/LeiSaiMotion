using csdmc1c80;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.DLL
{
    internal class HomeDLL
    {
        // 回零运动
        public static void StartHome(Home home)
        {
            // 脉冲输出模式
            dmc1c80.d1c80_set_pulse_outmode(0, 0);
            dmc1c80.d1c80_set_pulse_outmode(1, 0);

            // 原点信号配置
            dmc1c80.d1c80_config_HOME_PIN_logic(home.Axis, 0, 1);

            // 回零模式
            dmc1c80.d1c80_config_home_mode(
                home.Axis,
                home.HomeMode,
                home.StartSpeed,
                home.HomeSignal,
                0
            );

            // 速度加速度
            dmc1c80.d1c80_set_profile(
                home.Axis,
                home.StartSpeed,
                home.MaxSpeed,
                home.Acc,
                home.Acc
            );

            // 启动回零
            dmc1c80.d1c80_home_move(home.Axis);
        }
    }
}
