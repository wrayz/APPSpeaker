using System.Globalization;

namespace APPEyesFree
{
    /// <summary>
    /// 訊息工廠
    /// </summary>
    public static class MessageFactory
    {
        /// <summary>
        /// 訊息取得
        /// </summary>
        /// <param name="culture"></param>
        public static string GetDefaultMessage(CultureInfo culture)
        {
            switch (culture.Name)
            {
                case "zh-TW":
                    return "異常";

                case "zh-CN":
                    return "异常";

                case "zh-HK":
                    return "異常";

                case "ja-JP":
                    return "異常";

                default:
                    return "Error";
            }
        }
    }
}