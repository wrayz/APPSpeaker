using Microsoft.Speech.Synthesis;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        /// <param name="devices"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static List<PromptBuilder> TextConvert(IEnumerable<Device> devices, CultureInfo culture)
        {
            //語音內容
            List<PromptBuilder> builders = new List<PromptBuilder>();

            if (devices.Count() > 0)
            {
                foreach (Device device in devices)
                {
                    PromptBuilder builder = new PromptBuilder(culture);

                    if (string.IsNullOrEmpty(device.ERROR_INFO))
                        device.ERROR_INFO = MessageFactory.GetDefaultMessage(culture);

                    //過濾特殊字元
                    string name = Regex.Replace(device.DEVICE_NAME, @"[\W_]+", " ");
                    string info = Regex.Replace(device.ERROR_INFO, @"[\W_]+", " ");

                    builder.AppendText(name);
                    builder.AppendBreak(PromptBreak.Small);
                    builder.AppendText(info);

                    builders.Add(builder);
                }
            }

            return builders;
        }
    }
}