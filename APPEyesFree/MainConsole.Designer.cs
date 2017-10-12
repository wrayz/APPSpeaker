using System;
using System.Threading;
namespace APPEyesFree
{
    partial class MainConsole
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainConsole));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage_program = new System.Windows.Forms.TabPage();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.tabPage_settings = new System.Windows.Forms.TabPage();
            this.button_test_connection = new System.Windows.Forms.Button();
            this.textBox_source_server = new System.Windows.Forms.TextBox();
            this.label_source_database = new System.Windows.Forms.Label();
            this.numericUpDown_volume = new System.Windows.Forms.NumericUpDown();
            this.label_volume = new System.Windows.Forms.Label();
            this.numericUpDown_rate = new System.Windows.Forms.NumericUpDown();
            this.label_rate = new System.Windows.Forms.Label();
            this.label_language = new System.Windows.Forms.Label();
            this.comboBox_language = new System.Windows.Forms.ComboBox();
            this.checkBox_include_fix = new System.Windows.Forms.CheckBox();
            this.button_save = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.tabPage_program.SuspendLayout();
            this.tabPage_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rate)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage_program);
            this.TabControl.Controls.Add(this.tabPage_settings);
            this.TabControl.Location = new System.Drawing.Point(13, 13);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(585, 229);
            this.TabControl.TabIndex = 0;
            // 
            // tabPage_program
            // 
            this.tabPage_program.Controls.Add(this.textBox_log);
            this.tabPage_program.Controls.Add(this.button_start);
            this.tabPage_program.Controls.Add(this.button_exit);
            this.tabPage_program.Controls.Add(this.button_clear);
            this.tabPage_program.Location = new System.Drawing.Point(4, 22);
            this.tabPage_program.Name = "tabPage_program";
            this.tabPage_program.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_program.Size = new System.Drawing.Size(577, 203);
            this.tabPage_program.TabIndex = 0;
            this.tabPage_program.Text = "Program";
            this.tabPage_program.UseVisualStyleBackColor = true;
            // 
            // textBox_log
            // 
            this.textBox_log.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBox_log.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_log.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_log.Location = new System.Drawing.Point(16, 24);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.Size = new System.Drawing.Size(434, 172);
            this.textBox_log.TabIndex = 4;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(467, 24);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(95, 35);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "&Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(467, 161);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(95, 35);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "&Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(467, 65);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(95, 35);
            this.button_clear.TabIndex = 1;
            this.button_clear.Text = "&Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // tabPage_settings
            // 
            this.tabPage_settings.Controls.Add(this.button_test_connection);
            this.tabPage_settings.Controls.Add(this.textBox_source_server);
            this.tabPage_settings.Controls.Add(this.label_source_database);
            this.tabPage_settings.Controls.Add(this.numericUpDown_volume);
            this.tabPage_settings.Controls.Add(this.label_volume);
            this.tabPage_settings.Controls.Add(this.numericUpDown_rate);
            this.tabPage_settings.Controls.Add(this.label_rate);
            this.tabPage_settings.Controls.Add(this.label_language);
            this.tabPage_settings.Controls.Add(this.comboBox_language);
            this.tabPage_settings.Controls.Add(this.checkBox_include_fix);
            this.tabPage_settings.Controls.Add(this.button_save);
            this.tabPage_settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_settings.Name = "tabPage_settings";
            this.tabPage_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_settings.Size = new System.Drawing.Size(577, 203);
            this.tabPage_settings.TabIndex = 1;
            this.tabPage_settings.Text = "Settings";
            this.tabPage_settings.UseVisualStyleBackColor = true;
            // 
            // button_test_connection
            // 
            this.button_test_connection.Location = new System.Drawing.Point(467, 24);
            this.button_test_connection.Name = "button_test_connection";
            this.button_test_connection.Size = new System.Drawing.Size(95, 22);
            this.button_test_connection.TabIndex = 18;
            this.button_test_connection.Text = "&Test";
            this.button_test_connection.UseVisualStyleBackColor = true;
            this.button_test_connection.Click += new System.EventHandler(this.button_test_connection_Click);
            // 
            // textBox_source_server
            // 
            this.textBox_source_server.Location = new System.Drawing.Point(131, 24);
            this.textBox_source_server.Name = "textBox_source_server";
            this.textBox_source_server.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_source_server.Size = new System.Drawing.Size(282, 22);
            this.textBox_source_server.TabIndex = 17;
            // 
            // label_source_database
            // 
            this.label_source_database.AutoSize = true;
            this.label_source_database.Location = new System.Drawing.Point(28, 24);
            this.label_source_database.Name = "label_source_database";
            this.label_source_database.Size = new System.Drawing.Size(78, 12);
            this.label_source_database.TabIndex = 16;
            this.label_source_database.Text = "SourceDatabase";
            // 
            // numericUpDown_volume
            // 
            this.numericUpDown_volume.Location = new System.Drawing.Point(131, 123);
            this.numericUpDown_volume.Name = "numericUpDown_volume";
            this.numericUpDown_volume.Size = new System.Drawing.Size(62, 22);
            this.numericUpDown_volume.TabIndex = 15;
            // 
            // label_volume
            // 
            this.label_volume.AutoSize = true;
            this.label_volume.Location = new System.Drawing.Point(29, 123);
            this.label_volume.Name = "label_volume";
            this.label_volume.Size = new System.Drawing.Size(42, 12);
            this.label_volume.TabIndex = 14;
            this.label_volume.Text = "Volume";
            // 
            // numericUpDown_rate
            // 
            this.numericUpDown_rate.Location = new System.Drawing.Point(131, 90);
            this.numericUpDown_rate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_rate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDown_rate.Name = "numericUpDown_rate";
            this.numericUpDown_rate.Size = new System.Drawing.Size(62, 22);
            this.numericUpDown_rate.TabIndex = 13;
            // 
            // label_rate
            // 
            this.label_rate.AutoSize = true;
            this.label_rate.Location = new System.Drawing.Point(29, 90);
            this.label_rate.Name = "label_rate";
            this.label_rate.Size = new System.Drawing.Size(26, 12);
            this.label_rate.TabIndex = 12;
            this.label_rate.Text = "Rate";
            // 
            // label_language
            // 
            this.label_language.AutoSize = true;
            this.label_language.Location = new System.Drawing.Point(29, 56);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(51, 12);
            this.label_language.TabIndex = 11;
            this.label_language.Text = "Language";
            // 
            // comboBox_language
            // 
            this.comboBox_language.FormattingEnabled = true;
            this.comboBox_language.Location = new System.Drawing.Point(131, 56);
            this.comboBox_language.Name = "comboBox_language";
            this.comboBox_language.Size = new System.Drawing.Size(200, 20);
            this.comboBox_language.TabIndex = 10;
            // 
            // checkBox_include_fix
            // 
            this.checkBox_include_fix.AutoSize = true;
            this.checkBox_include_fix.Location = new System.Drawing.Point(30, 161);
            this.checkBox_include_fix.Name = "checkBox_include_fix";
            this.checkBox_include_fix.Size = new System.Drawing.Size(127, 16);
            this.checkBox_include_fix.TabIndex = 9;
            this.checkBox_include_fix.Text = "Include Fixing Device";
            this.checkBox_include_fix.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(467, 161);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(95, 35);
            this.button_save.TabIndex = 8;
            this.button_save.Text = "&Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // MainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 254);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainConsole";
            this.Text = "EyesFree";
            this.TabControl.ResumeLayout(false);
            this.tabPage_program.ResumeLayout(false);
            this.tabPage_program.PerformLayout();
            this.tabPage_settings.ResumeLayout(false);
            this.tabPage_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rate)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage_program;
        private System.Windows.Forms.TabPage tabPage_settings;
        private System.Windows.Forms.Button button_test_connection;
        private System.Windows.Forms.TextBox textBox_source_server;
        private System.Windows.Forms.Label label_source_database;
        private System.Windows.Forms.NumericUpDown numericUpDown_volume;
        private System.Windows.Forms.Label label_volume;
        private System.Windows.Forms.NumericUpDown numericUpDown_rate;
        private System.Windows.Forms.Label label_rate;
        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.ComboBox comboBox_language;
        private System.Windows.Forms.CheckBox checkBox_include_fix;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.TextBox textBox_log;

        #endregion

        /// <summary>
        /// Config 設置初始
        /// </summary>
        private void InitializeConfig()
        {
            var config = ConfigAccess.GetConfig();

            //語言清單加入
            AddLanguageList();

            //Server
            this.textBox_source_server.Text = config.Server;
            //語言
            this.comboBox_language.SelectedValue = config.Language;
            //速度
            this.numericUpDown_rate.Value = config.Rate.Value;
            //音量
            this.numericUpDown_volume.Value = Convert.ToInt32(config.Volume);
            //修復時是否告警
            this.checkBox_include_fix.Checked = config.IncludeFix == "Y";
            //版本資訊
            this.textBox_log.AppendText("EyesFree Ver1.0" + Environment.NewLine);
        }

        /// <summary>
        /// 語言清單加入
        /// </summary>
        private void AddLanguageList()
        {
            var voices = TTSService.GetInstalledVoice();

            //選單設定
            this.comboBox_language.DisplayMember = "Name";
            this.comboBox_language.ValueMember = "Culture";

            this.comboBox_language.DataSource = voices;
        }
    }
}

