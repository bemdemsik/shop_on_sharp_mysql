using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using shop.Classes;
using System.IO;
namespace shop.Forms
{
    public partial class ProductAddOrChange : Form
    {
        string path = "";
        string imageName = "";
        string imageName1 = "";
        string request = "";
        string oldSearch = "";
        string oldFilt = "";
        string where = "";
        string oldOrderBy = "";
        int numberPage = 1;
        int oldNumberRowActive = 0;
        public ProductAddOrChange()
        {
            InitializeComponent();
            comboBoxCategory.Items.AddRange(DataFillArray.Read("select categoryName from categoryproduct", 0));
            comboBoxManufacturer.Items.AddRange(DataFillArray.Read("select manufacturerName from manufacturer", 0));
            button2.Text = "Добавить";
            pictureBoxProduct.Image = Image.FromFile(Directory.GetCurrentDirectory() + @"\\photo\\picture.png");
        }
        public ProductAddOrChange(DataGridViewRow row, int numberRowActive, string search, string filt, string orderby, int numberActivePage)
        {
            oldSearch = search;
            oldFilt = filt;
            oldOrderBy = orderby;
            numberPage = numberActivePage;
            oldNumberRowActive = numberRowActive;
            InitializeComponent();
            imageName1 = row.Cells["Артикул"].Value.ToString() + ".png";
            textArticule.Text = row.Cells["Артикул"].Value.ToString();
            textCost.Text = row.Cells["Цена"].Value.ToString();
            textCountInStock.Text = row.Cells["Остаток на складе"].Value.ToString();
            textDiscount.Text = row.Cells["Скидка"].Value.ToString();
            textNameProduct.Text = row.Cells["Наименование"].Value.ToString();
            comboBoxCategory.Items.AddRange(DataFillArray.Read("select categoryName from categoryproduct", 0));
            comboBoxCategory.Text = row.Cells["Категория"].Value.ToString();
            comboBoxManufacturer.Items.AddRange(DataFillArray.Read("select manufacturerName from manufacturer", 0));
            comboBoxManufacturer.Text = row.Cells["Производитель"].Value.ToString();
            textDescripstion.Text = row.Cells["Описание"].Value.ToString();
            try
            {
                using (Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\\photo\\" + row.Cells["image"].Value.ToString()))
                {
                    pictureBoxProduct.Image = new Bitmap(img);
                }
            }
            catch
            {
                using (Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\\photo\\picture.png"))
                {
                    pictureBoxProduct.Image = new Bitmap(img);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product q;
            if (button2.Text == "Сохранить")
                q = new Product(oldNumberRowActive, oldSearch, oldFilt, oldOrderBy, numberPage);
            else
                q = new Product(where);
            q.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox text in Controls.OfType<TextBox>())
            {
                if (text.Name != "textDescripstion" && text.Name != "textDiscount" && text.Text == "")
                {
                    MessageBox.Show("Вы заполнили не все поля", "Внимание", MessageBoxButtons.OK);
                    return;
                }
            }
            if (comboBoxCategory.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля", "Внимание", MessageBoxButtons.OK);
                return;
            }
            int discount = 0;
            if (textDiscount.Text != "")
                discount = Convert.ToInt32(textDiscount.Text);
            if (button2.Text == "Сохранить")
            {
                request = "update product set articule='" + textArticule.Text + "',productName='" + textNameProduct.Text + "',idCategory=(select id from categoryproduct where categoryName='" + comboBoxCategory.Text + "'),description='" + textDescripstion.Text + "',cost=" + textCost.Text + ",discount=" + discount + ",image='" + imageName1 + "',idManufacturer=(select id from manufacturer where manufacturerName='" + comboBoxManufacturer.Text + "'), unit='шт.',countStock='" + textCountInStock.Text + "' where articule='" + textArticule.Text + "'";
            }
            else
            {
                if (imageName != "")
                    imageName1 = textArticule.Text + ".png";
                request = "insert into product (articule,productName,idCategory,description,cost,discount,image,idManufacturer,unit,countStock) values('" + textArticule.Text + "','" + textNameProduct.Text + "',(select id from categoryproduct where categoryName='" + comboBoxCategory.Text + "'),'" + textDescripstion.Text + "'," + textCost.Text.Replace(",", ".") + ",'" + discount + "','" + imageName1 + "',(select id from manufacturer where manufacturerName='" + comboBoxManufacturer.Text + "'),'шт.','" + textCountInStock.Text + "')";
            }
            if (Request.RequestData(request))
            {
                if (imageName != "")
                {
                    if (File.Exists(Directory.GetCurrentDirectory() + @"\\photo\\" + imageName1))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + @"\\photo\\" + imageName1);
                    }
                    File.Copy(path + @"\\" + imageName, Directory.GetCurrentDirectory() + @"\\photo\\" + imageName1);
                }
                where = " order by case when articule='" + textArticule.Text + "' then 1 else 2 end ";
                MessageBox.Show("Запрос выполнен успешно", "Ура", MessageBoxButtons.OK);
                if (button2.Text == "Добавить")
                {
                    foreach (TextBox text in Controls.OfType<TextBox>())
                        text.Clear();
                    foreach (ComboBox combo in Controls.OfType<ComboBox>())
                        combo.SelectedIndex = -1;
                    using (Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\\photo\\picture.png"))
                    {
                        pictureBoxProduct.Image = new Bitmap(img);
                    }
                    imageName1 = imageName = "";
                }
            }
            else
            {
                MessageBox.Show("Возникла ошибка, попробуйте позже", "Внимание", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            openFileDialog.InitialDirectory = @"d\\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = Path.GetDirectoryName(openFileDialog.FileName);
                imageName = openFileDialog.SafeFileName;
                using (Image img = Image.FromFile(path + @"\\" + imageName))
                {
                    pictureBoxProduct.Image = new Bitmap(img);
                }
            }
            openFileDialog.Dispose();
        }

        private void textCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[0-9]|[\b]"))
                e.Handled = true;
        }
        private void ru_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
        }
        private void en_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
        }
    }
}
