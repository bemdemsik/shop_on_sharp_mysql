
namespace shop.Forms
{
    partial class User
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxOrderBy = new System.Windows.Forms.ComboBox();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nextlabel = new System.Windows.Forms.Label();
            this.backlabel = new System.Windows.Forms.Label();
            this.labelAllCountDataRows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1195, 529);
            this.dataGridView1.TabIndex = 1231;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "В меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1066, 609);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(842, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 24);
            this.label6.TabIndex = 1237;
            this.label6.Text = "Сортировка по дате рождения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 1235;
            this.label4.Text = "Поиск по ФИО";
            // 
            // comboBoxOrderBy
            // 
            this.comboBoxOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderBy.FormattingEnabled = true;
            this.comboBoxOrderBy.Location = new System.Drawing.Point(846, 36);
            this.comboBoxOrderBy.Name = "comboBoxOrderBy";
            this.comboBoxOrderBy.Size = new System.Drawing.Size(233, 32);
            this.comboBoxOrderBy.TabIndex = 1234;
            this.comboBoxOrderBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderBy_SelectedIndexChanged);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(12, 36);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(342, 29);
            this.textSearch.TabIndex = 1232;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 614);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 24);
            this.label3.TabIndex = 1240;
            this.label3.Text = "1/10";
            // 
            // nextlabel
            // 
            this.nextlabel.AutoSize = true;
            this.nextlabel.Location = new System.Drawing.Point(638, 614);
            this.nextlabel.Name = "nextlabel";
            this.nextlabel.Size = new System.Drawing.Size(21, 24);
            this.nextlabel.TabIndex = 1239;
            this.nextlabel.Text = ">";
            this.nextlabel.Click += new System.EventHandler(this.nextlabel_Click);
            // 
            // backlabel
            // 
            this.backlabel.AutoSize = true;
            this.backlabel.Location = new System.Drawing.Point(539, 614);
            this.backlabel.Name = "backlabel";
            this.backlabel.Size = new System.Drawing.Size(21, 24);
            this.backlabel.TabIndex = 1238;
            this.backlabel.Text = "<";
            this.backlabel.Click += new System.EventHandler(this.backlabel_Click);
            // 
            // labelAllCountDataRows
            // 
            this.labelAllCountDataRows.AutoSize = true;
            this.labelAllCountDataRows.Location = new System.Drawing.Point(416, 614);
            this.labelAllCountDataRows.Name = "labelAllCountDataRows";
            this.labelAllCountDataRows.Size = new System.Drawing.Size(20, 24);
            this.labelAllCountDataRows.TabIndex = 1242;
            this.labelAllCountDataRows.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 24);
            this.label1.TabIndex = 1241;
            this.label1.Text = "Общее количество записей:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 24);
            this.label5.TabIndex = 1244;
            this.label5.Text = "Фильтрация по роли";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(477, 36);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(242, 32);
            this.comboBoxFilter.TabIndex = 1243;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilter_SelectedIndexChanged);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 656);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.labelAllCountDataRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nextlabel);
            this.Controls.Add(this.backlabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxOrderBy);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxOrderBy;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nextlabel;
        private System.Windows.Forms.Label backlabel;
        private System.Windows.Forms.Label labelAllCountDataRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxFilter;
    }
}