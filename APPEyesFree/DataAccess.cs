using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace APPEyesFree
{
    /// <summary>
    /// 資料存取
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// 異常設備清單取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Device> GetErrorDevices()
        {
            //資料庫連線
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            //異常設備清單
            List<Device> list = new List<Device>();

            //SQL語句
            string sql = @"SELECT * FROM dms.VW_ERROR_DEVICES";
            //SQL執行語法
            SqlCommand cmd = new SqlCommand(sql, connection);

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                //資料
                SqlDataReader data = cmd.ExecuteReader();
                //ORA
                while (data.Read())
                {
                    Device device = new Device
                    {
                        DEVICE_SN = data["DEVICE_SN"].ToString(),
                        DEVICE_ID = data["DEVICE_ID"].ToString(),
                        DEVICE_NAME = data["DEVICE_NAME"].ToString(),
                        DEVICE_STATUS = data["DEVICE_STATUS"].ToString(),
                        ERROR_INFO = data["ERROR_INFO"].ToString(),
                        ERROR_TIME = Convert.ToDateTime(data["ERROR_TIME"])
                    };

                    list.Add(device);
                }
                //資料庫連線關閉
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //物件清除
                connection.Close();
                connection.Dispose();
            }

            return list;
        }
    }
}