using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPEyesFree
{
    /// <summary>
    /// 設備資訊
    /// </summary>
    public class Device
    {
        /// <summary>
        /// 設備編號
        /// </summary>
        public string DEVICE_SN { get; set; }

        /// <summary>
        /// 設備對應ID
        /// </summary>
        public string DEVICE_ID { get; set; }

        /// <summary>
        /// 設備名稱
        /// </summary>
        public string DEVICE_NAME { get; set; }

        /// <summary>
        /// 設備狀態
        /// </summary>
        public string DEVICE_STATUS { get; set; }

        /// <summary>
        /// 異常紀錄資訊
        /// </summary>
        public string ERROR_INFO { get; set; }

        /// <summary>
        /// 異常紀錄時間
        /// </summary>
        public DateTime? ERROR_TIME { get; set; }
    }
}
