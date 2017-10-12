using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace APPEyesFree
{
    public partial class MainConsole : Form
    {
        //語音告警啟用狀態
        private bool _isOn = false;

        //語音告警程序
        private Thread _thread;

        /// <summary>
        /// 建構式
        /// </summary>
        public MainConsole()
        {
            InitializeComponent();
            InitializeConfig();
            _thread = new Thread(Speech);
        }

        /// <summary>
        /// 設置儲存按鈕事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                var config = new Config
                {
                    Server = textBox_source_server.Text,
                    Language = comboBox_language.SelectedValue.ToString(),
                    Rate = Convert.ToInt32(numericUpDown_rate.Value),
                    Volume = Convert.ToInt32(numericUpDown_volume.Value),
                    IncludeFix = checkBox_include_fix.Checked ? "Y" : "N"
                };

                ConfigAccess.ModifyConfig(config);

                MessageBox.Show("Setting Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 連線測試
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_test_connection_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Server={0};Database=EyesFree;User ID=eipmgr; password=eipmgr", textBox_source_server.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeed.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 語音告警啟動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_Click(object sender, EventArgs e)
        {
            //切換狀態
            _isOn = !_isOn;
            //啟用按鈕文字內容
            button_start.Text = _isOn ? "&Stop" : "&Start";
            //設定功能
            tabPage_settings.Enabled = !_isOn;
            //log textbox 加入啟用敘述
            textBox_log.AppendText((_isOn ? "Alarm actived." : "Alarm stopped.") + Environment.NewLine);

            //語音告警程序
            if (_isOn && !_thread.IsAlive)
            {
                //語音告警程序啟用
                _thread.Start();
            }
            else
            {
                //語音告警程序中止
                _thread.Abort();
                //重設thread
                _thread = new Thread(Speech);
            }
        }

        /// <summary>
        /// 清除Log紀錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_log.Clear();
        }

        /// <summary>
        /// 離開程式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 語音告警
        /// </summary>
        private void Speech()
        {
            var config = ConfigAccess.GetConfig();

            var dao = new DataAccess();

            TTSService tts = new TTSService(config);

            try
            {
                while (true)
                {
                    var devices = dao.GetErrorDevices();
                    //更新log 訊息
                    if (textBox_log.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            UpdateTextBox(devices);
                        });
                    }

                    if (config.IncludeFix == "N")
                        devices = devices.Where(device => device.DEVICE_STATUS == "E");

                    var builders = TextBuilder.TextConvert(devices, tts.Culture);
                    tts.Speech(builders);
                }
            }
            catch (ThreadAbortException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tts.Dispose();
            }
        }

        /// <summary>
        /// 更新log 訊息
        /// </summary>
        /// <param name="devices"></param>
        private void UpdateTextBox(IEnumerable<Device> devices)
        {
            foreach (var device in devices)
            {
                //Log新增
                textBox_log.AppendText(string.Format("{0} {1} {2}", device.DEVICE_NAME, device.ERROR_INFO, device.ERROR_TIME) + Environment.NewLine);
            }
        }
    }
}