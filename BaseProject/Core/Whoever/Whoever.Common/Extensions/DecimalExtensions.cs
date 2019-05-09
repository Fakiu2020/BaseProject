namespace Whoever.Common.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToPercentageString(this decimal @decimal)
        {
            return (@decimal / 100).ToString("p2");
        }
    }
}
