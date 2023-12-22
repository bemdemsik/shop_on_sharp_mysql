
namespace shop.Forms
{
    partial class ProductAddOrChange
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
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxManufacturer = new System.Windows.Forms.ComboBox();
            this.textArticule = new System.Windows.Forms.TextBox();
            this.textNameProduct = new System.Windows.Forms.TextBox();
            this.textDiscount = new System.Windows.Forms.TextBox();
            this.textCost = new System.Windows.Forms.TextBox();
            this.textCountInStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxProduct = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textDescripstion = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(122, 82);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(267, 32);
            this.comboBoxCategory.TabIndex = 2;
            // 
            // comboBoxManufacturer
            // 
            this.comboBoxManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxManufacturer.FormattingEnabled = true;
            this.comboBoxManufacturer.Location = new System.Drawing.Point(170, 196);
            this.comboBoxManufacturer.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxManufacturer.Name = "comboBoxManufacturer";
            this.comboBoxManufacturer.Size = new System.Drawing.Size(219, 32);
            this.comboBoxManufacturer.TabIndex = 5;
            // 
            // textArticule
            // 
            this.textArticule.Location = new System.Drawing.Point(97, 45);
            this.textArticule.Name = "textArticule";
            this.textArticule.Size = new System.Drawing.Size(292, 29);
            this.textArticule.TabIndex = 1;
            this.textArticule.Enter += new System.EventHandler(this.en_Enter);
            // 
            // textNameProduct
            // 
            this.textNameProduct.Location = new System.Drawing.Point(226, 10);
            this.textNameProduct.Name = "textNameProduct";
            this.textNameProduct.Size = new System.Drawing.Size(397, 29);
            this.textNameProduct.TabIndex = 0;
            this.textNameProduct.Enter += new System.EventHandler(this.ru_Enter);
            // 
            // textDiscount
            // 
            this.textDiscount.Location = new System.Drawing.Point(213, 158);
            this.textDiscount.MaxLength = 2;
            this.textDiscount.Name = "textDiscount";
            this.textDiscount.Size = new System.Drawing.Size(176, 29);
            this.textDiscount.TabIndex = 4;
            this.textDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCost_KeyPress);
            // 
            // textCost
            // 
            this.textCost.Location = new System.Drawing.Point(124, 123);
            this.textCost.MaxLength = 10;
            this.textCost.Name = "textCost";
            this.textCost.Size = new System.Drawing.Size(265, 29);
            this.textCost.TabIndex = 3;
            this.textCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCost_KeyPress);
            // 
            // textCountInStock
            // 
            this.textCountInStock.Location = new System.Drawing.Point(192, 237);
            this.textCountInStock.MaxLength = 10;
            this.textCountInStock.Name = "textCountInStock";
            this.textCountInStock.Size = new System.Drawing.Size(197, 29);
            this.textCountInStock.TabIndex = 7;
            this.textCountInStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCost_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 118;
            this.label1.Text = "Артикул";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 24);
            this.label2.TabIndex = 91;
            this.label2.Text = "Наименование товара";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Производитель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Категория";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Действующая скидка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 24);
            this.label6.TabIndex = 91;
            this.label6.Text = "Остаток на складе";
            // 
            // pictureBoxProduct
            // 
            this.pictureBoxProduct.Location = new System.Drawing.Point(398, 45);
            this.pictureBoxProduct.Name = "pictureBoxProduct";
            this.pictureBoxProduct.Size = new System.Drawing.Size(225, 183);
            this.pictureBoxProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProduct.TabIndex = 15;
            this.pictureBoxProduct.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "Стоимость";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "К товарам";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(488, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 34);
            this.button2.TabIndex = 10;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 24);
            this.label9.TabIndex = 20;
            this.label9.Text = "Описание";
            // 
            // textDescripstion
            // 
            this.textDescripstion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textDescripstion.Location = new System.Drawing.Point(114, 307);
            this.textDescripstion.MaxLength = 200;
            this.textDescripstion.Multiline = true;
            this.textDescripstion.Name = "textDescripstion";
            this.textDescripstion.Size = new System.Drawing.Size(509, 114);
            this.textDescripstion.TabIndex = 8;
            this.textDescripstion.Enter += new System.EventHandler(this.ru_Enter);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(440, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 57);
            this.button3.TabIndex = 9;
            this.button3.Text = "Изменить картинку";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ProductAddOrChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(631, 468);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textDescripstion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBoxProduct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textCountInStock);
            this.Controls.Add(this.textCost);
            this.Controls.Add(this.textDiscount);
            this.Controls.Add(this.textNameProduct);
            this.Controls.Add(this.textArticule);
            this.Controls.Add(this.comboBoxManufacturer);
            this.Controls.Add(this.comboBoxCategory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ProductAddOrChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление\\Изменение товаров";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxManufacturer;
        private System.Windows.Forms.TextBox textArticule;
        private System.Windows.Forms.TextBox textNameProduct;
        private System.Windows.Forms.TextBox textDiscount;
        private System.Windows.Forms.TextBox textCost;
        private System.Windows.Forms.TextBox textCountInStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textDescripstion;
        private System.Windows.Forms.Button button3;
    }
}