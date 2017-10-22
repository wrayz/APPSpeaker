using Microsoft.Speech.Synthesis;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace APPEyesFree
{
    /// <summary>
    /// 語音告警服務
    /// </summary>
    public class TTSService : IDisposable
    {
        //是否釋放資源
        private bool _disposed = false;

        //系統資源控制
        private SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        //語音物件
        private SpeechSynthesizer _synth;

        //語言
        public string Language { get; set; }

        //語系
        public CultureInfo Culture
        {
            get
            {
                return new CultureInfo(Language);
            }
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="config"></param>
        public TTSService()
        {
            //語音物件
            _synth = new SpeechSynthesizer();
        }

        /// <summary>
        /// 語音設置
        /// </summary>
        /// <param name="config"></param>
        public void SetConfig(Config config)
        {
            //語言
            Language = config.Language;
            //語音速度
            _synth.Rate = config.Rate.Value;
            //語音音量
            _synth.Volume = config.Volume.Value;
            //語言
            _synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 1, Culture);
            //設定輸出
            _synth.SetOutputToDefaultAudioDevice();
        }

        /// <summary>
        /// 以安裝語音取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Voice> GetInstalledVoice()
        {
            List<Voice> voices = new List<Voice>();

            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    var voiceInfo = new Voice
                    {
                        Name = info.Culture.EnglishName,
                        Culture = info.Culture.Name
                    };

                    voices.Add(voiceInfo);
                }
            }

            return voices;
        }

        /// <summary>
        /// 語音發出
        /// </summary>
        /// <param name="builders">文字內容物件</param>
        public void Speech(Config config, List<PromptBuilder> builders)
        {
            //語音
            foreach (var builder in builders)
            {
                _synth.Speak(builder);
            }
        }

        /// <summary>
        /// 資源釋放
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _handle.Dispose();
                _synth.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// 解構子
        /// </summary>
        ~TTSService()
        {
            Dispose(false);
        }
    }
}