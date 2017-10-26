using System;
namespace APPEyesFree
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_language = new System.Windows.Forms.Label();
            this.label_rate = new System.Windows.Forms.Label();
            this.label_volume = new System.Windows.Forms.Label();
            this.comboBox_language = new System.Windows.Forms.ComboBox();
            this.numericUpDown_rate = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_volume = new System.Windows.Forms.NumericUpDown();
            this.checkBox_include_fix = new System.Windows.Forms.CheckBox();
            this.button_connection = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_volume)).BeginInit();
            this.SuspendLayout();
            // 
            // label_language
            // 
            this.label_language.AutoSize = true;
            this.label_language.Location = new System.Drawing.Point(14, 15);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(51, 12);
            this.label_language.TabIndex = 22;
            this.label_language.Text = "Language";
            // 
            // label_rate
            // 
            this.label_rate.AutoSize = true;
            this.label_rate.Location = new System.Drawing.Point(39, 45);
            this.label_rate.Name = "label_rate";
            this.label_rate.Size = new System.Drawing.Size(26, 12);
            this.label_rate.TabIndex = 23;
            this.label_rate.Text = "Rate";
            // 
            // label_volume
            // 
            this.label_volume.AutoSize = true;
            this.label_volume.Location = new System.Drawing.Point(23, 75);
            this.label_volume.Name = "label_volume";
            this.label_volume.Size = new System.Drawing.Size(42, 12);
            this.label_volume.TabIndex = 25;
            this.label_volume.Text = "Volume";
            // 
            // comboBox_language
            // 
            this.comboBox_language.FormattingEnabled = true;
            this.comboBox_language.Location = new System.Drawing.Point(80, 15);
            this.comboBox_language.Name = "comboBox_language";
            this.comboBox_language.Size = new System.Drawing.Size(200, 20);
            this.comboBox_language.TabIndex = 21;
            // 
            // numericUpDown_rate
            // 
            this.numericUpDown_rate.Location = new System.Drawing.Point(80, 45);
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
            this.numericUpDown_rate.TabIndex = 24;
            // 
            // numericUpDown_volume
            // 
            this.numericUpDown_volume.Location = new System.Drawing.Point(80, 75);
            this.numericUpDown_volume.Name = "numericUpDown_volume";
            this.numericUpDown_volume.Size = new System.Drawing.Size(62, 22);
            this.numericUpDown_volume.TabIndex = 26;
            // 
            // checkBox_include_fix
            // 
            this.checkBox_include_fix.AutoSize = true;
            this.checkBox_include_fix.Location = new System.Drawing.Point(16, 105);
            this.checkBox_include_fix.Name = "checkBox_include_fix";
            this.checkBox_include_fix.Size = new System.Drawing.Size(127, 16);
            this.checkBox_include_fix.TabIndex = 20;
            this.checkBox_include_fix.Text = "Include Fixing Device";
            this.checkBox_include_fix.UseVisualStyleBackColor = true;
            // 
            // button_connection
            // 
            this.button_connection.Location = new System.Drawing.Point(12, 135);
            this.button_connection.Name = "button_connection";
            this.button_connection.Size = new System.Drawing.Size(100, 25);
            this.button_connection.TabIndex = 28;
            this.button_connection.Text = "&ConnectionSetting";
            this.button_connection.UseVisualStyleBackColor = true;
            this.button_connection.Click += new System.EventHandler(this.button_connection_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(129, 135);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 25);
            this.button_save.TabIndex = 19;
            this.button_save.Text = "&Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(210, 135);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 25);
            this.button_cancel.TabIndex = 29;
            this.button_cancel.Text = "&Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 173);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_connection);
            this.Controls.Add(this.numericUpDown_volume);
            this.Controls.Add(this.label_volume);
            this.Controls.Add(this.numericUpDown_rate);
            this.Controls.Add(this.label_rate);
            this.Controls.Add(this.label_language);
            this.Controls.Add(this.comboBox_language);
            this.Controls.Add(this.checkBox_include_fix);
            this.Controls.Add(this.button_save);
            this.MaximizeBox = false;
            this.Name = "SettingsDialog";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_volume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.Label label_rate;
        private System.Windows.Forms.Label label_volume;
        private System.Windows.Forms.ComboBox comboBox_language;
        private System.Windows.Forms.NumericUpDown numericUpDown_rate;
        private System.Windows.Forms.NumericUpDown numericUpDown_volume;
        private System.Windows.Forms.CheckBox checkBox_include_fix;
        private System.Windows.Forms.Button button_connection;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
    }
}