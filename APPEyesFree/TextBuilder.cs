using System.Globalization;
using System.Speech.Synthesis;

namespace APPEyesFree
{
    /// <summary>
    /// 語音字串組合器
    /// </summary>
    public static class TextBuilder
    {
        /// <summary>
        /// 字串轉換語音
        /// </summary>
        /// <param name="log"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static PromptBuilder TextConvert(EventLog log, CultureInfo culture)
        {
            //語音內容
            var builder = new PromptBuilder(culture);

            if (string.IsNullOrEmpty(log.LOG_INFO))
                log.LOG_INFO = MessageFactory.GetDefaultMessage(culture);

            builder.AppendTextWithHint(log.DEVICE_NAME, SayAs.NumberCardinal);
            builder.AppendBreak(PromptBreak.Small);
            builder.AppendTextWithHint(log.LOG_INFO, SayAs.NumberCardinal);
            builder.AppendBreak(PromptBreak.ExtraSmall);

            return builder;
        }
    }
}