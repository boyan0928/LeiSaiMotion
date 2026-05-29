namespace Project
{
    /// <summary>
    /// 卡号与轴号换算。每张卡本地轴 0-11，全局轴 = 卡索引 * 12 + 本地轴。
    /// </summary>
    internal static class CardAxis
    {
        public const int AxesPerCard = 12;

        public static ushort ToGlobalAxis(int cardIndex, int localAxis)
        {
            return (ushort)(cardIndex * AxesPerCard + localAxis);
        }

        public static ushort ToCardNo(int cardIndex)
        {
            return (ushort)cardIndex;
        }
    }
}
