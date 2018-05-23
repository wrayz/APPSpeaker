using System;
using System.Windows.Forms;

namespace APPEyesFree
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
            //設置初始
            InitializeConfig();
        }

        /// <summary>
        /// Config 設置初始
        /// </summary>
        private void InitializeConfig()
        {
            //Config 取得
            var config = DataAccess.GetConfig();

            //語言清單加入
            SetLanguageList();

            //語言
            comboBox_language.SelectedValue = config.Language;
            //速度
            numericUpDown_rate.Value = config.Rate.Value;
            //音量
            numericUpDown_volume.Value = Convert.ToInt32(config.Volume);
            //簡易告警循環次數
            numericUpDown_cycle.Value = Convert.ToInt32(config.SpeechCycle);
            //修復時是否告警
            checkBox_include_fix.Checked = config.IncludeFix == "Y";
        }

        /// <summary>
        /// 語言清單加入
        /// </summary>
        private void SetLanguageList()
        {
            var voices = TTSService.GetInstalledVoice();

            //選單設定
            comboBox_language.DisplayMember = "Name";
            comboBox_language.ValueMember = "Culture";

            comboBox_language.DataSource = voices;
        }

        ///// <summary>
        ///// 資料庫連線設定
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Button_connection_Click(object sender, EventArgs e)
        //{
        //    using (var dialog = new ConnectionSettings())
        //    {
        //        //位置置中
        //        dialog.StartPosition = FormStartPosition.CenterParent;
        //        //彈跳視窗開啟
        //        dialog.ShowDialog(this);
        //    }
        //}

        /// <summary>
        /// 儲存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_save_Click(object sender, EventArgs e)
        {
            try
            {
                var config = new Config
                {
                    Language = comboBox_language.SelectedValue.ToString(),
                    Rate = Convert.ToInt32(numericUpDown_rate.Value),
                    Volume = Convert.ToInt32(numericUpDown_volume.Value),
                    SpeechCycle = Convert.ToInt32(numericUpDown_cycle.Value),
                    IncludeFix = checkBox_include_fix.Checked ? "Y" : "N"
                };

                DataAccess.ModifyConfig(config);

                MessageBox.Show("Setting Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}