using System;
using System.Configuration;
using System.Data.SqlClient;

namespace APPEyesFree
{
    /// <summary>
    /// Config 設置存取
    /// </summary>
    public class ConfigAccess
    {
        /// <summary>
        /// Config 取得
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            var config = new Config
            {
                Server = GetConnectionServer(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString),
                Language = ConfigurationManager.AppSettings["language"],
                Rate = Convert.ToInt32(ConfigurationManager.AppSettings["rate"]),
                Volume = Convert.ToInt32(ConfigurationManager.AppSettings["volume"]),
                IncludeFix = ConfigurationManager.AppSettings["includeFix"]
            };

            return config;
        }

        /// <summary>
        /// Config 更改
        /// </summary>
        /// <param name="config">設置</param>
        public static void ModifyConfig(Config config)
        {
            Configuration file = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = file.AppSettings;

            file.ConnectionStrings.ConnectionStrings["connectionString"].ConnectionString = SetConnectionString(config.Server);
            app.Settings["language"].Value = config.Language;
            app.Settings["rate"].Value = config.Rate.ToString();
            app.Settings["volume"].Value = config.Volume.ToString();
            app.Settings["includeFix"].Value = config.IncludeFix.ToString();

            file.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Connection Server取得
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        private static string GetConnectionServer(string connectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            return builder.DataSource;
        }

        /// <summary>
        /// ConnectionString設置
        /// </summary>
        /// <param name="server">來源實體</param>
        /// <returns></returns>
        private static string SetConnectionString(string server)
        {
            return string.Format("Server={0};Database=EyesFree;User ID=eipmgr; password=eipmgr", server);
        }
    }
}