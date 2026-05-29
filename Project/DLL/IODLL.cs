using csdmc1c80;
using System;

namespace Project.DLL
{
    internal class IODLL
    {
        /// <summary>
        /// 界面显示 Out-0 / IN-0 起编，雷赛 API 的 bitno 从 1 起编。
        /// </summary>
        public static ushort ToApiBitNo(int displayIndex)
        {
            return (ushort)(displayIndex + 1);
        }

        public static int ReadInput(ushort cardNo, int displayIndex)
        {
            return dmc1c80.d1c80_read_inbit(cardNo, ToApiBitNo(displayIndex));
        }

        public static int ReadOutput(ushort cardNo, int displayIndex)
        {
            return dmc1c80.d1c80_read_outbit(cardNo, ToApiBitNo(displayIndex));
        }

        public static void WriteOutput(ushort cardNo, int displayIndex, ushort value)
        {
            dmc1c80.d1c80_write_outbit(cardNo, ToApiBitNo(displayIndex), value);
        }

        public static uint ReadAxisIoStatus(ushort axisNo)
        {
            return dmc1c80.d1c80_axis_io_status(axisNo);
        }

        /// <summary>硬件读值转界面状态：0=开(亮)，非0=关。</summary>
        public static int HardwareToUiState(int hwValue)
        {
            return hwValue == 0 ? 1 : 0;
        }
    }
}
