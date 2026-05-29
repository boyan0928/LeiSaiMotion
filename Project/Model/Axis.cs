using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    internal class Axis
    {
        // 轴号
        public ushort AxisNumber { get; set; }

        // 方向 1 / -1
        public int Direction { get; set; } = 1;

        // 距离
        public int Distance { get; set; }

        // 速度
        public double MinVel { get; set; }
        public double MaxVel { get; set; }

        // 加速度
        public double Tac { get; set; }
        public double STac { get; set; }

        // 运动模式 0=T曲线 1=S曲线
        public int MotionMode { get; set; } = 0;
    }
}
