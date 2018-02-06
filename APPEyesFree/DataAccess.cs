using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace APPEyesFree
{
    /// <summary>
    /// 資料存取
    /// </summary>
    public static class DataAccess
    {
        /// <summary>
        /// 告警設定取得
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            //資料庫連線
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            //SQL語句
            string sql = @"SELECT * FROM dms.VW_SPEECH_CONFIG";
            //SQL執行語法
            SqlCommand cmd = new SqlCommand(sql, connection);
            //Config
            var config = new Config();

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
                    config.Language = data["SPEECH_LANGUAGE"].ToString();
                    config.Rate = Convert.ToInt32(data["SPEECH_RATE"]);
                    config.Volume = Convert.ToInt32(data["SPEECH_VOLUME"]);
                    config.IncludeFix = data["SPEECH_REPAIR"].ToString();

                    break;
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

            return config;
        }

        /// <summary>
        /// 異常設備清單取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Device> GetErrorDevices()
        {
            //資料庫連線
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            //異常設備清單
            List<Device> list = new List<Device>();

            //SQL語句
            string sql = @"SELECT * FROM dms.VW_ERROR_DEVICE";
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

        /// <summary>
        /// Config 設置變更
        /// </summary>
        /// <param name="config"></param>
        public static void ModifyConfig(Config config)
        {
            //資料庫連線
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            //SQL執行語法
            SqlCommand cmd = new SqlCommand("dms.SPC_TTS_UPDATE", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            //執行參數
            cmd.Parameters.Add("@SPEECH_LANGUAGE", SqlDbType.NVarChar).Value = config.Language;
            cmd.Parameters.Add("@SPEECH_RATE", SqlDbType.NVarChar).Value = config.Rate;
            cmd.Parameters.Add("@SPEECH_VOLUME", SqlDbType.NVarChar).Value = config.Volume;
            cmd.Parameters.Add("@SPEECH_REPAIR", SqlDbType.VarChar).Value = config.IncludeFix;

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                //執行SPC
                cmd.ExecuteNonQuery();
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
        }
    }
}