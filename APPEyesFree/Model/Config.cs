namespace APPEyesFree
{
    /// <summary>
    /// 告警App設置
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 資料庫Server
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// 語言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 速度
        /// </summary>
        public int? Rate { get; set; }

        /// <summary>
        /// 音量
        /// </summary>
        public int? Volume { get; set; }

        /// <summary>
        /// 是否包含修復中設備
        /// </summary>
        public string IncludeFix { get; set; }
    }
}