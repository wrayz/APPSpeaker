using Microsoft.Speech.Synthesis;
using System.Globalization;
using System.Text.RegularExpressions;

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
        /// <param name="device"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static PromptBuilder TextConvert(Device device, CultureInfo culture)
        {
            //語音內容
            PromptBuilder builder = new PromptBuilder(culture);

            if (string.IsNullOrEmpty(device.ERROR_INFO))
                device.ERROR_INFO = MessageFactory.GetDefaultMessage(culture);

            //過濾特殊字元
            string name = Regex.Replace(device.DEVICE_NAME, @"[^a-zA-Z0-9\.]+", " ");
            string info = Regex.Replace(device.ERROR_INFO, @"[^a-zA-Z0-9\.]+", " ");

            builder.AppendTextWithHint(name, SayAs.NumberCardinal);
            builder.AppendBreak(PromptBreak.Small);
            builder.AppendTextWithHint(info, SayAs.NumberCardinal);
            builder.AppendBreak(PromptBreak.ExtraSmall);

            return builder;
        }
    }
}