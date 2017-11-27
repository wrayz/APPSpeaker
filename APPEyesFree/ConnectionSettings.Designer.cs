namespace APPEyesFree
{
    partial class ConnectionSettings
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
            this.label_server = new System.Windows.Forms.Label();
            this.label_database = new System.Windows.Forms.Label();
            this.label_userId = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_database = new System.Windows.Forms.TextBox();
            this.textBox_userId = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_test_connection = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_server = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Location = new System.Drawing.Point(12, 18);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(65, 12);
            this.label_server.TabIndex = 30;
            this.label_server.Text = "Server Name";
            // 
            // label_database
            // 
            this.label_database.AutoSize = true;
            this.label_database.Location = new System.Drawing.Point(31, 48);
            this.label_database.Name = "label_database";
            this.label_database.Size = new System.Drawing.Size(46, 12);
            this.label_database.TabIndex = 33;
            this.label_database.Text = "Database";
            // 
            // label_userId
            // 
            this.label_userId.AutoSize = true;
            this.label_userId.Location = new System.Drawing.Point(36, 78);
            this.label_userId.Name = "label_userId";
            this.label_userId.Size = new System.Drawing.Size(41, 12);
            this.label_userId.TabIndex = 34;
            this.label_userId.Text = "User ID";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(31, 108);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(48, 12);
            this.label_password.TabIndex = 35;
            this.label_password.Text = "Password";
            // 
            // textBox_database
            // 
            this.textBox_database.Location = new System.Drawing.Point(85, 45);
            this.textBox_database.Name = "textBox_database";
            this.textBox_database.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_database.Size = new System.Drawing.Size(180, 22);
            this.textBox_database.TabIndex = 36;
            // 
            // textBox_userId
            // 
            this.textBox_userId.Location = new System.Drawing.Point(85, 75);
            this.textBox_userId.Name = "textBox_userId";
            this.textBox_userId.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_userId.Size = new System.Drawing.Size(130, 22);
            this.textBox_userId.TabIndex = 37;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(85, 105);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_password.Size = new System.Drawing.Size(130, 22);
            this.textBox_password.TabIndex = 38;
            // 
            // button_test_connection
            // 
            this.button_test_connection.Location = new System.Drawing.Point(12, 138);
            this.button_test_connection.Name = "button_test_connection";
            this.button_test_connection.Size = new System.Drawing.Size(100, 25);
            this.button_test_connection.TabIndex = 32;
            this.button_test_connection.Text = "&Test";
            this.button_test_connection.UseVisualStyleBackColor = true;
            this.button_test_connection.Click += new System.EventHandler(this.button_test_connection_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(185, 138);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(100, 25);
            this.button_save.TabIndex = 40;
            this.button_save.Text = "&Connect";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_server
            // 
            this.textBox_server.Location = new System.Drawing.Point(85, 15);
            this.textBox_server.Name = "textBox_server";
            this.textBox_server.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_server.Size = new System.Drawing.Size(180, 22);
            this.textBox_server.TabIndex = 41;
            // 
            // ConnectionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 176);
            this.Controls.Add(this.label_server);
            this.Controls.Add(this.label_database);
            this.Controls.Add(this.label_userId);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textBox_server);
            this.Controls.Add(this.textBox_database);
            this.Controls.Add(this.textBox_userId);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.button_test_connection);
            this.Controls.Add(this.button_save);
            this.MaximizeBox = false;
            this.Name = "ConnectionSettings";
            this.Text = "Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.Label label_database;
        private System.Windows.Forms.Label label_userId;
        private System.Windows.Forms.Label label_password;
        //private System.Windows.Forms.ComboBox comboBox_server;
        private System.Windows.Forms.TextBox textBox_server;
        private System.Windows.Forms.TextBox textBox_database;
        private System.Windows.Forms.TextBox textBox_userId;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_test_connection;
        private System.Windows.Forms.Button button_save;


    }
}