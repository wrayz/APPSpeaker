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
            //版本資訊
            textBox_log.AppendText("EyesFree Ver1.0" + Environment.NewLine);
            //視窗關閉事件
            FormClosing += MainConsole_FormClosing;
        }

        /// <summary>
        /// 主視窗初始事件 (開啟資料庫連線設定)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainConsole_Load(object sender, EventArgs e)
        {
            //開啟語音告警
            StartToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// 主視窗關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainConsole_FormClosing(object sender, EventArgs e)
        {
            //告警程序終止
            if (_thread != null)
                _thread.Abort();
        }

        /// <summary>
        /// 語音告警啟動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //切換狀態
            _isOn = true;
            //應用程式狀態
            SetStatus();

            //語音告警程序啟用
            _thread = new Thread(Speech);
            _thread.Start();
        }

        /// <summary>
        /// 語音告警停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //語音告警程序中止
            _thread.Abort();

            //切換狀態
            _isOn = false;
            //應用程式狀態
            SetStatus();
        }

        /// <summary>
        /// 清除Log紀錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_log.Clear();
        }

        /// <summary>
        /// 離開程式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //告警程序終止
            if (_thread != null)
                _thread.Abort();

            Application.Exit();
        }

        /// <summary>
        /// 語音告警
        /// </summary>
        private void Speech()
        {
            var tts = new TTSService();

            try
            {
                while (true)
                {
                    //設定
                    var config = DataAccess.GetConfig();
                    tts.SetConfig(config);

                    //告警類型事件紀錄資料
                    var alarmLogs = DataAccess.GetAlarmLogs();
                    //數據及狀態類型事件紀錄資料
                    var eventLogs = DataAccess.GetEventLogs();

                    if (config.IncludeFix == "N")
                        eventLogs = eventLogs.Where(log => log.IS_REPAIRING == "N");

                    //設備告警播放清單
                    var speechList = new List<EventLog>();

                    //告警類型事件紀錄資料加入
                    if (alarmLogs.Count() > 0)
                    {
                        for (var i = 0; i < config.SpeechCycle.Value; i++)
                        {
                            speechList.AddRange(alarmLogs);
                        }
                    }

                    //一般異常設備加入
                    speechList.AddRange(eventLogs);

                    foreach (var device in speechList)
                    {
                        //更新log 訊息
                        if (textBox_log.InvokeRequired)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                UpdateTextBox(device);
                            });
                        }

                        var builder = TextBuilder.TextConvert(device, tts.Culture);
                        tts.Speech(builder);
                    }
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
        /// 更新 log 顯示訊息
        /// </summary>
        /// <param name="log">紀錄資訊</param>
        private void UpdateTextBox(EventLog log)
        {
            //Log新增
            textBox_log.AppendText(string.Format("{0} {1} {2}", log.DEVICE_NAME, log.LOG_INFO, log.LOG_TIME) + Environment.NewLine);
        }

        /// <summary>
        /// 應用程式狀態
        /// </summary>
        private void SetStatus()
        {
            //啟用按鈕可否使用
            startToolStripMenuItem.Enabled = !_isOn;
            //啟用按鈕可否使用
            stopToolStripMenuItem.Enabled = _isOn;
            //log textbox 加入啟用敘述
            textBox_log.AppendText((_isOn ? "Alarm actived." : "Alarm stopped.") + Environment.NewLine);
        }

        /// <summary>
        /// 設置彈跳視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SettingsDialog())
            {
                //位置置中
                dialog.StartPosition = FormStartPosition.CenterParent;
                //彈跳視窗開啟
                dialog.ShowDialog(this);
            }
        }
    }
}