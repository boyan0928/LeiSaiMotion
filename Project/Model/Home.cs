using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    internal class Home
    {
        // 轴号
        public ushort Axis { get; set; }

        // 速度
        public double StartSpeed { get; set; }
        public double MaxSpeed { get; set; }
        public double Acc { get; set; }

        // 回零模式
        public ushort HomeMode { get; set; }
        public ushort HomeSignal { get; set; }
    }
}
