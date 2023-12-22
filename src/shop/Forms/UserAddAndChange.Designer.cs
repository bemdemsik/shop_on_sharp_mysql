
namespace shop.Forms
{
    partial class UserAddAndChange
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textPasswd = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textFIO = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AllowDrop = true;
            this.maskedTextBox1.Location = new System.Drawing.Point(109, 167);
            this.maskedTextBox1.Mask = "+7(000)000-00-00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(185, 29);
            this.maskedTextBox1.TabIndex = 21;
            this.maskedTextBox1.TextChanged += new System.EventHandler(this.maskedTextBox1_TextChanged);
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(73, 205);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(221, 32);
            this.comboBoxRole.TabIndex = 19;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(169, 129);
            this.dateTimePicker1.MaxDate = new System.DateTime(2023, 5, 21, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(206, 29);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.Value = new System.DateTime(2023, 5, 21, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textPasswd
            // 
            this.textPasswd.Location = new System.Drawing.Point(95, 90);
            this.textPasswd.Name = "textPasswd";
            this.textPasswd.Size = new System.Drawing.Size(177, 29);
            this.textPasswd.TabIndex = 13;
            this.textPasswd.Enter += new System.EventHandler(this.en_Enter);
            this.textPasswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwdKeyPress);
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(90, 51);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(182, 29);
            this.textLogin.TabIndex = 9;
            this.textLogin.Enter += new System.EventHandler(this.en_Enter);
            this.textLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginKeyPress);
            // 
            // textFIO
            // 
            this.textFIO.Location = new System.Drawing.Point(80, 12);
            this.textFIO.Name = "textFIO";
            this.textFIO.Size = new System.Drawing.Size(439, 29);
            this.textFIO.TabIndex = 8;
            this.textFIO.Enter += new System.EventHandler(this.ru_Enter);
            this.textFIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fioKeyPress);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(278, 88);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(241, 35);
            this.button6.TabIndex = 15;
            this.button6.Text = "Сгенерировать пароль";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(278, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(241, 35);
            this.button5.TabIndex = 11;
            this.button5.Text = "Сгенерировать логин";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 24);
            this.label6.TabIndex = 20;
            this.label6.Text = "Роль:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "Телефон:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Дата рождения:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Логин:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "ФИО:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(382, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 34);
            this.button2.TabIndex = 22;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 256);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(151, 34);
            this.button1.TabIndex = 23;
            this.button1.Text = "К просмотру";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserAddAndChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(529, 300);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textPasswd);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.textFIO);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UserAddAndChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление и изменение пользователя";
            this.Load += new System.EventHandler(this.UserAddAndChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textPasswd;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textFIO;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}