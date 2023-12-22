
namespace shop.Forms
{
    partial class ShowOrders
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAllCountDataRows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nextlabel = new System.Windows.Forms.Label();
            this.backlabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxOrderBy = new System.Windows.Forms.ComboBox();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.просмотрСтруктурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьСтатусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinish = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerPo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerS = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxStaff = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 24);
            this.label5.TabIndex = 1257;
            this.label5.Text = "Фильтрация по дате заказа";
            // 
            // labelAllCountDataRows
            // 
            this.labelAllCountDataRows.AutoSize = true;
            this.labelAllCountDataRows.Location = new System.Drawing.Point(420, 614);
            this.labelAllCountDataRows.Name = "labelAllCountDataRows";
            this.labelAllCountDataRows.Size = new System.Drawing.Size(20, 24);
            this.labelAllCountDataRows.TabIndex = 1255;
            this.labelAllCountDataRows.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 24);
            this.label1.TabIndex = 1254;
            this.label1.Text = "Общее количество записей:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(708, 614);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 24);
            this.label3.TabIndex = 1253;
            this.label3.Text = "1/10";
            // 
            // nextlabel
            // 
            this.nextlabel.AutoSize = true;
            this.nextlabel.Location = new System.Drawing.Point(769, 614);
            this.nextlabel.Name = "nextlabel";
            this.nextlabel.Size = new System.Drawing.Size(21, 24);
            this.nextlabel.TabIndex = 1252;
            this.nextlabel.Text = ">";
            this.nextlabel.Click += new System.EventHandler(this.nextlabel_Click);
            // 
            // backlabel
            // 
            this.backlabel.AutoSize = true;
            this.backlabel.Location = new System.Drawing.Point(670, 614);
            this.backlabel.Name = "backlabel";
            this.backlabel.Size = new System.Drawing.Size(21, 24);
            this.backlabel.TabIndex = 1251;
            this.backlabel.Text = "<";
            this.backlabel.Click += new System.EventHandler(this.backlabel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(930, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 24);
            this.label6.TabIndex = 1250;
            this.label6.Text = "Сортировка по стоимости";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 1249;
            this.label4.Text = "Поиск по ФИО";
            // 
            // comboBoxOrderBy
            // 
            this.comboBoxOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderBy.FormattingEnabled = true;
            this.comboBoxOrderBy.Location = new System.Drawing.Point(934, 36);
            this.comboBoxOrderBy.Name = "comboBoxOrderBy";
            this.comboBoxOrderBy.Size = new System.Drawing.Size(233, 32);
            this.comboBoxOrderBy.TabIndex = 1248;
            this.comboBoxOrderBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderBy_SelectedIndexChanged);
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(16, 36);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(342, 29);
            this.textSearch.TabIndex = 1247;
            this.textSearch.TextChanged += new System.EventHandler(this.textSearch_TextChanged);
            this.textSearch.Enter += new System.EventHandler(this.ru_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 1245;
            this.button1.Text = "В меню";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(-1, 74);
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
            this.dataGridView1.Size = new System.Drawing.Size(1467, 529);
            this.dataGridView1.TabIndex = 1246;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView1_CellContextMenuStripNeeded);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.просмотрСтруктурыToolStripMenuItem,
            this.изменитьСтатусToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(268, 48);
            // 
            // просмотрСтруктурыToolStripMenuItem
            // 
            this.просмотрСтруктурыToolStripMenuItem.Name = "просмотрСтруктурыToolStripMenuItem";
            this.просмотрСтруктурыToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.просмотрСтруктурыToolStripMenuItem.Text = "Просмотр структуры";
            this.просмотрСтруктурыToolStripMenuItem.Click += new System.EventHandler(this.просмотрСтруктурыToolStripMenuItem_Click);
            // 
            // изменитьСтатусToolStripMenuItem
            // 
            this.изменитьСтатусToolStripMenuItem.Name = "изменитьСтатусToolStripMenuItem";
            this.изменитьСтатусToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.изменитьСтатусToolStripMenuItem.Text = "Изменить статус или дату доставки";
            this.изменитьСтатусToolStripMenuItem.Click += new System.EventHandler(this.изменитьСтатусToolStripMenuItem_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(424, 35);
            this.dateTimePickerStart.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(206, 29);
            this.dateTimePickerStart.TabIndex = 1258;
            this.dateTimePickerStart.Value = new System.DateTime(2023, 5, 26, 0, 0, 0, 0);
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1251, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 58);
            this.button2.TabIndex = 1259;
            this.button2.Text = "Очистить условия просмотра";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxStatus);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Location = new System.Drawing.Point(514, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 143);
            this.groupBox1.TabIndex = 1260;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изменение статуса и даты получения";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 24);
            this.label7.TabIndex = 1264;
            this.label7.Text = "Статус";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(165, 65);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(233, 32);
            this.comboBoxStatus.TabIndex = 1263;
            this.comboBoxStatus.Enter += new System.EventHandler(this.ru_Enter);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 33);
            this.button4.TabIndex = 1262;
            this.button4.Text = "Закрыть";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(269, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 33);
            this.button3.TabIndex = 1261;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 24);
            this.label2.TabIndex = 1260;
            this.label2.Text = "Дата получения";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(165, 30);
            this.dateTimePicker2.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(233, 29);
            this.dateTimePicker2.TabIndex = 1259;
            this.dateTimePicker2.Value = new System.DateTime(2023, 5, 21, 0, 0, 0, 0);
            // 
            // dateTimePickerFinish
            // 
            this.dateTimePickerFinish.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFinish.Location = new System.Drawing.Point(679, 35);
            this.dateTimePickerFinish.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerFinish.Name = "dateTimePickerFinish";
            this.dateTimePickerFinish.Size = new System.Drawing.Size(206, 29);
            this.dateTimePickerFinish.TabIndex = 1261;
            this.dateTimePickerFinish.Value = new System.DateTime(2023, 5, 26, 0, 0, 0, 0);
            this.dateTimePickerFinish.ValueChanged += new System.EventHandler(this.dateTimePickerFinish_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(395, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 24);
            this.label8.TabIndex = 1262;
            this.label8.Text = "С";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(639, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 24);
            this.label9.TabIndex = 1263;
            this.label9.Text = "По";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(934, 609);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(519, 33);
            this.button5.TabIndex = 1264;
            this.button5.Text = "Отчет за выбранный период и выбранного сотрудника";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePickerPo);
            this.groupBox2.Controls.Add(this.dateTimePickerS);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.comboBoxStaff);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(449, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(559, 152);
            this.groupBox2.TabIndex = 1265;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбирите период и сотрудника";
            // 
            // dateTimePickerPo
            // 
            this.dateTimePickerPo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPo.Location = new System.Drawing.Point(347, 30);
            this.dateTimePickerPo.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerPo.Name = "dateTimePickerPo";
            this.dateTimePickerPo.Size = new System.Drawing.Size(206, 29);
            this.dateTimePickerPo.TabIndex = 1268;
            this.dateTimePickerPo.Value = new System.DateTime(2023, 5, 29, 0, 0, 0, 0);
            this.dateTimePickerPo.ValueChanged += new System.EventHandler(this.dateTimePickerPo_ValueChanged);
            // 
            // dateTimePickerS
            // 
            this.dateTimePickerS.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerS.Location = new System.Drawing.Point(46, 30);
            this.dateTimePickerS.MaxDate = new System.DateTime(9998, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerS.Name = "dateTimePickerS";
            this.dateTimePickerS.Size = new System.Drawing.Size(206, 29);
            this.dateTimePickerS.TabIndex = 1267;
            this.dateTimePickerS.Value = new System.DateTime(2023, 5, 29, 0, 0, 0, 0);
            this.dateTimePickerS.ValueChanged += new System.EventHandler(this.dateTimePickerS_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(307, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 24);
            this.label12.TabIndex = 1266;
            this.label12.Text = "По";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 24);
            this.label10.TabIndex = 1264;
            this.label10.Text = "Сотрудник";
            // 
            // comboBoxStaff
            // 
            this.comboBoxStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStaff.FormattingEnabled = true;
            this.comboBoxStaff.Location = new System.Drawing.Point(119, 68);
            this.comboBoxStaff.Name = "comboBoxStaff";
            this.comboBoxStaff.Size = new System.Drawing.Size(434, 32);
            this.comboBoxStaff.TabIndex = 1263;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 110);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(129, 33);
            this.button6.TabIndex = 1262;
            this.button6.Text = "Закрыть";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(424, 110);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(129, 33);
            this.button7.TabIndex = 1261;
            this.button7.Text = "Создать";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 24);
            this.label11.TabIndex = 1260;
            this.label11.Text = "С";
            // 
            // ShowOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1465, 649);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePickerFinish);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelAllCountDataRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nextlabel);
            this.Controls.Add(this.backlabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxOrderBy);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ShowOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр заказов";
            this.Load += new System.EventHandler(this.ShowOrders_Load);
            this.Click += new System.EventHandler(this.ShowOrders_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAllCountDataRows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nextlabel;
        private System.Windows.Forms.Label backlabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxOrderBy;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem просмотрСтруктурыToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem изменитьСтатусToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinish;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePickerPo;
        private System.Windows.Forms.DateTimePicker dateTimePickerS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxStaff;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label11;
    }
}