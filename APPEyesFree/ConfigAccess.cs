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
                Server = GetConnectionStringBuilder().DataSource,
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
        /// Connection Builder取得
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        /// <returns></returns>
        public static SqlConnectionStringBuilder GetConnectionStringBuilder()
        {
            return new SqlConnectionStringBuilder(GetConnectionString());;
        }

        /// <summary>
        /// ConnectionString取得
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        /// <summary>
        /// ConnectionString設置
        /// </summary>
        /// <param name="server">來源實體</param>
        /// <returns></returns>
        private static string SetConnectionString(string server)
        {
            var builder = GetConnectionStringBuilder();
            builder.DataSource = server;
            return builder.ConnectionString;
        }
    }
}