using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace APPEyesFree
{
    public partial class ConnectionSettings : Form
    {
        public ConnectionSettings()
        {
            InitializeComponent();
            //設置初始
            InitializeConfig();
        }

        /// <summary>
        /// Connection 設置初始
        /// </summary>
        private void InitializeConfig()
        {
            //ConnectionStrings 取得
            var connectionBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            
            textBox_server.Text = connectionBuilder.DataSource;
            //Database
            textBox_database.Text = connectionBuilder.InitialCatalog;
            //登入ID
            textBox_userId.Text = connectionBuilder.UserID;
            //密碼
            textBox_password.Text = connectionBuilder.Password;
        }

        /// <summary>
        /// 連線測試
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_test_connection_Click(object sender, System.EventArgs e)
        {
            try
            {
                var helper = new SqlHelper(GetConnectionString());
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 設置儲存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_save_Click(object sender, EventArgs e)
        {
            try
            {
                var file = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                file.ConnectionStrings.ConnectionStrings["connectionString"].ConnectionString = GetConnectionString();
                file.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ConnectionString取得
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            var connectionBuilder = new SqlConnectionStringBuilder();

            //伺服器
            connectionBuilder.DataSource = textBox_server.Text;
            //Database
            connectionBuilder.InitialCatalog = textBox_database.Text;
            //登入ID
            connectionBuilder.UserID = textBox_userId.Text;
            //密碼
            connectionBuilder.Password = textBox_password.Text;

            return connectionBuilder.ConnectionString;
        }
    }
}