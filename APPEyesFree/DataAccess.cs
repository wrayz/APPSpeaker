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
            var sql = @"SELECT * FROM dms.VW_SPEECH_CONFIG";
            //SQL執行語法
            var cmd = new SqlCommand(sql, connection);
            //Config
            var config = new Config();

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                //資料
                var data = cmd.ExecuteReader();
                //ORA
                while (data.Read())
                {
                    config.Language = data["SPEECH_LANGUAGE"].ToString();
                    config.Rate = Convert.ToInt32(data["SPEECH_RATE"]);
                    config.Volume = Convert.ToInt32(data["SPEECH_VOLUME"]);
                    config.IncludeFix = data["SPEECH_REPAIR"].ToString();
                    config.SpeechCycle = Convert.ToInt32(data["SPEECH_CYCLE"]);

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
            var list = new List<Device>();

            //SQL語句
            var sql = @"SELECT * FROM dms.VW_ERROR_DEVICE";
            //SQL執行語法
            var cmd = new SqlCommand(sql, connection);

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                //資料
                var data = cmd.ExecuteReader();
                //ORA
                while (data.Read())
                {
                    var device = new Device
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
        /// 簡易告警異常設備清單取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Device> GetSimpleErrorDevices()
        {
            //資料庫連線
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            //異常設備清單
            var list = new List<Device>();
            //SPC 名稱
            var spcName = "SPC_SIMPLE_LOG_QUERY";

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                //執行SPC
                list = GetSimpleErrorDevice(spcName, connection);
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

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                ExecuteModifyConfig(config, "dms.SPC_TTS_UPDATE", connection);
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

        /// <summary>
        /// 執行更新設置
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connection"></param>
        private static void ExecuteModifyConfig(Config config, string name, SqlConnection connection)
        {
            //交易建立
            var transaction = connection.BeginTransaction();

            try
            {
                //SQL執行語法
                var cmd = new SqlCommand("dms.SPC_TTS_UPDATE", connection, transaction) { CommandType = CommandType.StoredProcedure };

                //執行參數
                cmd.Parameters.Add("@SPEECH_LANGUAGE", SqlDbType.NVarChar).Value = config.Language;
                cmd.Parameters.Add("@SPEECH_RATE", SqlDbType.NVarChar).Value = config.Rate;
                cmd.Parameters.Add("@SPEECH_VOLUME", SqlDbType.NVarChar).Value = config.Volume;
                cmd.Parameters.Add("@SPEECH_CYCLE", SqlDbType.VarChar).Value = config.SpeechCycle;
                cmd.Parameters.Add("@SPEECH_REPAIR", SqlDbType.VarChar).Value = config.IncludeFix;

                //執行SPC
                cmd.ExecuteNonQuery();
                //交易提交
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction.Connection != null)
                    //交易返回
                    transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        /// <summary>
        /// 取得簡易異常設備
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        private static List<Device> GetSimpleErrorDevice(string name, SqlConnection connection)
        {
            //異常設備清單
            var list = new List<Device>();
            //交易建立
            var transaction = connection.BeginTransaction();

            try
            {
                //SQL Procedure cmd
                var cmd = new SqlCommand("dms.SPC_SIMPLE_LOG_QUERY", connection, transaction) { CommandType = CommandType.StoredProcedure };

                //資料
                var reader = cmd.ExecuteReader();
                //ORA
                while (reader.Read())
                {
                    var device = new Device
                    {
                        DEVICE_SN = reader["DEVICE_SN"].ToString(),
                        DEVICE_ID = reader["DEVICE_ID"].ToString(),
                        DEVICE_NAME = reader["DEVICE_NAME"].ToString(),
                        ERROR_INFO = reader["ERROR_INFO"].ToString(),
                        ERROR_TIME = Convert.ToDateTime(reader["ERROR_TIME"])
                    };

                    list.Add(device);
                }
                reader.Close();
                //交易提交
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction.Connection != null)
                    //交易返回
                    transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
            }

            return list;
        }
    }
}