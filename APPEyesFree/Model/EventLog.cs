using System;

namespace APPEyesFree
{
    /// <summary>
    /// 事件紀錄資訊
    /// </summary>
    public class EventLog
    {
        /// <summary>
        /// 事件紀錄ID
        /// </summary>
        public int? LOG_ID { get; set; }

        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DEVICE_NAME { get; set; }

        /// <summary>
        /// 紀錄時間
        /// </summary>
        public DateTime? LOG_TIME { get; set; }

        /// <summary>
        /// 紀錄資訊
        /// </summary>
        public string LOG_INFO { get; set; }

        /// <summary>
        /// 是否正在修復(Y - 是, N - 否)
        /// </summary>
        public string IS_REPAIRING { get; set; }
    }
}