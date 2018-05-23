using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace APPEyesFree
{
    /// <summary>
    /// 資料存取
    /// </summary>
    public static class DataAccess
    {
        private static string _connectionsString;

        static DataAccess()
        {
            _connectionsString = GetConnectionString();
        }

        /// <summary>
        /// 告警設定取得
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            //資料庫連線
            var connection = new SqlConnection(_connectionsString);

            //SQL語句
            var sql = @"SELECT SPEECH_LANGUAGE, SPEECH_RATE, SPEECH_VOLUME, SPEECH_REPAIR, SPEECH_CYCLE
                        FROM dms.VW_TTS_CONFIG";
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
                var reader = cmd.ExecuteReader();
                //ORA
                while (reader.Read())
                {
                    config.Language = reader["SPEECH_LANGUAGE"].ToString();
                    config.Rate = Convert.ToInt16(reader["SPEECH_RATE"]);
                    config.Volume = Convert.ToInt16(reader["SPEECH_VOLUME"]);
                    config.IncludeFix = reader["SPEECH_REPAIR"].ToString();
                    config.SpeechCycle = Convert.ToInt16(reader["SPEECH_CYCLE"]);

                    break;
                }

                reader.Close();

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
        public static IEnumerable<EventLog> GetEventLogs()
        {
            //資料庫連線
            var connection = new SqlConnection(_connectionsString);
            //異常設備清單
            var list = new List<EventLog>();

            //SQL語句
            var sql = @"SELECT LOG_ID, DEVICE_NAME, LOG_TIME, LOG_INFO, IS_REPAIRING FROM elog.VW_TTS_EVENT_LOG";
            //SQL執行語法
            var cmd = new SqlCommand(sql, connection);

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                //資料
                var reader = cmd.ExecuteReader();
                //ORA
                while (reader.Read())
                {
                    var log = new EventLog
                    {
                        LOG_ID = Convert.ToInt32(reader["LOG_ID"]),
                        DEVICE_NAME = reader["DEVICE_NAME"].ToString(),
                        LOG_TIME = Convert.ToDateTime(reader["LOG_TIME"]),
                        LOG_INFO = reader["LOG_INFO"].ToString(),
                        IS_REPAIRING = reader["IS_REPAIRING"].ToString()
                    };

                    list.Add(log);
                }

                reader.Close();

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
        /// 告警類型事件紀錄清單取得
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<EventLog> GetAlarmLogs()
        {
            //資料庫連線
            var connection = new SqlConnection(_connectionsString);
            //異常設備清單
            var list = new List<EventLog>();

            //SQL語句
            var sql = @"SELECT LOG_ID, DEVICE_NAME, LOG_TIME, LOG_INFO, IS_REPAIRING FROM elog.VW_TTS_ALARM_LOG";
            //SQL執行語法
            var cmd = new SqlCommand(sql, connection);

            //執行
            try
            {
                //資料庫連線開啟
                connection.Open();
                //資料
                var reader = cmd.ExecuteReader();
                //ORA
                while (reader.Read())
                {
                    var log = new EventLog
                    {
                        LOG_ID = Convert.ToInt32(reader["LOG_ID"]),
                        DEVICE_NAME = reader["DEVICE_NAME"].ToString(),
                        LOG_TIME = Convert.ToDateTime(reader["LOG_TIME"]),
                        LOG_INFO = reader["LOG_INFO"].ToString(),
                        IS_REPAIRING = reader["IS_REPAIRING"].ToString()
                    };

                    list.Add(log);
                }

                reader.Close();

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
            var connection = new SqlConnection(_connectionsString);

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
        /// Get connection string
        /// </summary>
        private static string GetConnectionString()
        {
#if DEBUG
            return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
#else
            // Config name
            var configName = @"App.config";
            // Config path
            var configPath = Path.Combine(string.Format("{0}\\Config", Environment.CurrentDirectory), configName);

            var map = new ExeConfigurationFileMap { ExeConfigFilename = configPath };

            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            return config.ConnectionStrings.ConnectionStrings["connectionString"].ConnectionString;
#endif
        }
    }
}