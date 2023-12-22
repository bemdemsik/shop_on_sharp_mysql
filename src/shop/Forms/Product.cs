using System;
using System.Drawing;
using System.Text;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using shop.Classes;
using System.IO;
namespace shop.Forms
{
    public partial class Product : Form
    {
        string where = "";
        string request = "select articule as 'Артикул', productName as 'Наименование', (select categoryName from categoryproduct where id = idCategory) as 'Категория', description as 'Описание', cost as 'Цена', discount as 'Скидка', image, (select manufacturerName from manufacturer where id=idManufacturer) as 'Производитель', unit as 'Ед. измерения', countStock as 'Остаток на складе' from product";
        string poisk = "";
        string orderBy = "";
        string filt = "";
        string oldSearch = "";
        string oldFilt = "";
        string oldOrderBy = "";
        int countPage = 0;
        int numberPage = 1;
        int oldNumberPage = -1;
        int oldNumberRowActive = -1;
        bool checkNewColumns = false;
        int rowIndex = 0;
        public Product()
        {
            InitializeComponent();
        }
        public Product(string where1)
        {
            where = where1;
            InitializeComponent();
        }
        public Product(int numberRowActive1, string search1, string filt1, string orderby1, int numberActivePage1)
        {
            oldFilt = filt1;
            oldSearch = search1;
            oldOrderBy = orderby1;
            oldNumberPage = numberActivePage1;
            oldNumberRowActive = numberRowActive1;
            InitializeComponent();
        }
        private void ShowProduct()
        {
            labelAllCountDataRows.Text = ReadOneStr.Read("select count(*) from product " + filt)[0];
            countPage = Convert.ToInt32(Math.Ceiling(Convert.ToInt32(labelAllCountDataRows.Text) / 4.0));
            dataGridView1.DataSource = LoadData.Table(request + filt + poisk + orderBy + where + " limit " + ((numberPage - 1) * 4) + ", 4");
            try
            {
                dataGridView1.Columns["image"].Visible = false;
                dataGridView1.Columns["Описание"].Visible = false;
                dataGridView1.Columns["Скидка"].Visible = false;
                dataGridView1.Columns["Ед. измерения"].Visible = false;
                dataGridView1.Columns["Цена"].Visible = false;
            }
            catch
            {
                return;
            }
        }
        private void ShowImageAndCostAndCount()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    using (Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\\photo\\" + row.Cells["image"].Value.ToString()))
                    {
                        row.Cells["Картинка"].Value = new Bitmap(img);
                    }
                }
                catch
                {
                    using (Image img = Image.FromFile(Directory.GetCurrentDirectory() + @"\\photo\\picture.png"))
                    {
                        row.Cells["Картинка"].Value = new Bitmap(img);
                    }
                }
                if (row.Cells["Скидка"].Value.ToString() == "0")
                {
                    try
                    {
                        row.Cells["Скидка"].Value = Convert.ToInt32(DataFillArray.Read("select categoryDiscount from categoryproduct where categoryName='" + row.Cells["Категория"].Value.ToString() + "' and categoryDiscount != 0", 0)[0]);
                    }
                    catch
                    {
                        row.Cells["Скидка"].Value = 0;
                    }
                }
                if (row.Cells["Скидка"].Value.ToString() != "0")
                {
                    var oldCost = new StringBuilder();
                    foreach (var character in row.Cells["Цена"].Value.ToString())
                        oldCost.Append(character + "\u0336");
                    int newCost = 0;
                    try
                    {
                        newCost = Convert.ToInt32(row.Cells["Цена"].Value.ToString()) - Convert.ToInt32(row.Cells["Цена"].Value.ToString()) * Convert.ToInt32(row.Cells["Скидка"].Value.ToString()) / 100;
                        row.Cells["Стоимость"].Value = oldCost.ToString() + "\n" + newCost.ToString();
                    }
                    catch
                    {
                        row.Cells["Стоимость"].Value = oldCost.ToString();
                    }
                }
                else
                {
                    row.Cells["Стоимость"].Value = row.Cells["Цена"].Value.ToString();
                }
                if (Basket.GetBasket.Rows.Count != 0)
                {
                    try
                    {
                        DataRow row1 = Basket.GetBasket.Select("Артикул = '" + row.Cells["Артикул"].Value.ToString() + "'").FirstOrDefault();
                        if (row1 != null)
                        {
                            row.Cells["Остаток на складе"].Value = Convert.ToInt32(row.Cells["Остаток на складе"].Value.ToString()) - Convert.ToInt32(row1["Количество"].ToString());
                        }
                    }
                    catch
                    {
                        row.Cells["Остаток на складе"].Value = Convert.ToInt32(row.Cells["Остаток на складе"].Value.ToString());
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (UserInformation.GetRole == "Администратор" || UserInformation.GetRole == "Менеджер")
            {
                Main q = new Main();
                q.ShowDialog();
            }
            else
            {
                Autorization q = new Autorization();
                q.ShowDialog();
            }
        }
        private void Product_Load(object sender, EventArgs e)
        {
            if(UserInformation.GetRole != "Администратор" && UserInformation.GetRole != "Менеджер")
            {
                button2.Text = "Выход";
            }
            comboBoxFilter.Items.Add("Все категории");
            comboBoxFilter.Items.AddRange(DataFillArray.Read("select categoryName from categoryproduct", 0));
            comboBoxOrderBy.Items.Add("");
            comboBoxOrderBy.Items.Add("Возрастанию");
            comboBoxOrderBy.Items.Add("Убыванию");
            if (oldNumberPage != -1)
            {
                oldParameters();
                numberPage = oldNumberPage;
            }
            ShowProduct();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowImageAndCostAndCount();
            UI();
            if (oldNumberRowActive != -1)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[oldNumberRowActive].Selected = true;
            }
            foreach (DataGridViewColumn dgvc in dataGridView1.Columns)
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            where = "";
            dataGridView1.Columns["Производитель"].Width = 170;
            dataGridView1.Columns["Наименование"].Width = 250;
            dataGridView1.Columns["Категория"].Width = 150;
        }
        private void oldParameters()
        {
            textSearch.Text = oldSearch;
            comboBoxOrderBy.Text = oldOrderBy;
            comboBoxFilter.Text = oldFilt;
        }
        private void AddColumnsInDataGridView()
        {
            DataGridViewTextBoxColumn oldCost = new DataGridViewTextBoxColumn();
            oldCost.Name = "Стоимость";
            dataGridView1.Columns.Add(oldCost);
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image.ImageLayout = DataGridViewImageCellLayout.Zoom;
            image.Name = "Картинка";
            dataGridView1.Columns.Add(image);
            if (UserInformation.GetRole == "Администратор")
            {
                DataGridViewButtonColumn change = new DataGridViewButtonColumn();
                DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
                change.UseColumnTextForButtonValue = true;
                delete.UseColumnTextForButtonValue = true;
                change.Name = "Изменение";
                delete.Name = "Удаление";
                change.Text = "Изменить";
                delete.Text = "Удалить";
                change.Width = 160;
                dataGridView1.Columns.Add(change);
                dataGridView1.Columns.Add(delete);
            }
            else
            {
                button1.Visible = false;
            }
            checkNewColumns = true;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string check = dataGridView1.Rows[e.RowIndex].Cells["Артикул"].Value.ToString();
                check = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Удалить")
            {
                if (MessageBox.Show("Вы уверены что хотите удалить эту запись?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Request.RequestData("delete from product where articule='" + dataGridView1.Rows[e.RowIndex].Cells["Артикул"].Value.ToString() + "'"))
                    {
                        MessageBox.Show("Запись успешна удалена", "Ура", MessageBoxButtons.OK);
                        ShowProduct();
                        ShowImageAndCostAndCount();
                    }
                }
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Изменить")
            {
                this.Hide();
                ProductAddOrChange q = new ProductAddOrChange(dataGridView1.Rows[e.RowIndex], e.RowIndex, textSearch.Text, comboBoxFilter.Text, comboBoxOrderBy.Text, numberPage);
                q.ShowDialog();
            }
        }
        private void UI()
        {
            nextlabel.Enabled = true;
            backlabel.Enabled = true;
            if (numberPage == 1)
                backlabel.Enabled = false;
            if (numberPage == countPage)
                nextlabel.Enabled = false;
            label3.Text = numberPage + "/" + countPage;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filt = " where idCategory=(select id from categoryproduct where categoryName='" + comboBoxFilter.Text + "')";
            if (comboBoxFilter.Text == "Все категории")
                filt = "";
            numberPage = 1;
            ShowProduct();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowImageAndCostAndCount();
            UI();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrderBy.Text == "")
                orderBy = "";
            else if (comboBoxOrderBy.Text == "Возрастанию")
                orderBy = " order by (cost - cost * discount / 100)";
            else
                orderBy = " order by (cost - cost * discount / 100) desc";
            if (poisk != "")
            {
                orderBy = orderBy.Replace("order by ", ",");
            }
            numberPage = 1;
            ShowProduct();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowImageAndCostAndCount();
            UI();
        }
        private void nextlabel_Click(object sender, EventArgs e)
        {
            numberPage += 1;
            ShowProduct();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowImageAndCostAndCount();
            UI();
        }

        private void backlabel_Click(object sender, EventArgs e)
        {
            numberPage -= 1;
            ShowProduct();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowImageAndCostAndCount();
            UI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductAddOrChange q = new ProductAddOrChange();
            q.ShowDialog();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            poisk = " order by case when productName like '" + textSearch.Text + "%' then 1 when productName like '%" + textSearch.Text.ToLower() + "%' then 2 else 3 end";
            if (textSearch.Text == "")
            {
                if (orderBy != "")
                {
                    if (comboBoxOrderBy.Text == "")
                        orderBy = "";
                    else if (comboBoxOrderBy.Text == "Возрастанию")
                        orderBy = " order by (cost - cost * discount / 100)";
                    else
                        orderBy = " order by (cost - cost * discount / 100) desc";
                }
                poisk = "";
            }
            else
            {
                if (orderBy != "")
                {
                    if (comboBoxOrderBy.Text == "")
                        orderBy = "";
                    else if (comboBoxOrderBy.Text == "Возрастанию")
                        orderBy = " ,(cost - cost * discount / 100) ";
                    else
                        orderBy = " ,(cost - cost * discount / 100) desc ";
                }
            }
            numberPage = 1;
            ShowProduct();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowImageAndCostAndCount();
            UI();
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                rowIndex = e.RowIndex;
                contextMenuStrip1.Show(Cursor.Position);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
        private void добавитьВКорзинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[rowIndex].Cells["Остаток на складе"].Value.ToString() != "0")
            {
                dataGridView1.Rows[rowIndex].Cells["Остаток на складе"].Value = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Остаток на складе"].Value.ToString()) - 1;
            }
            else
            {
                MessageBox.Show("Вы не можете добавить товар в корзину, так как на складе его не осталось", "Внимание", MessageBoxButtons.OK);
                return;
            }
            if (Basket.GetBasket.Columns.Count == 0)
            {
                Basket.GetBasket.Columns.Add("Артикул");
                Basket.GetBasket.Columns.Add("Наименование");
                Basket.GetBasket.Columns.Add("Количество");
                Basket.GetBasket.Columns.Add("Стоимость");
                Basket.GetBasket.Columns.Add("Стоимость со скидкой");
                Basket.GetBasket.Columns.Add("Стоимость без скидки");
                Basket.GetBasket.Columns.Add("image");
                Basket.GetBasket.Columns.Add("Скидка");
                Basket.GetBasket.Columns.Add("Скидка в рублях");
            }
            DataRow row = Basket.GetBasket.Select("Артикул='" + dataGridView1.Rows[rowIndex].Cells["Артикул"].Value.ToString() + "'").FirstOrDefault();
            string oldCost1 = "";
            string newCost1 = "";
            string realCost = "";
            string discountInRubles = "";
            string[] Costs;
            realCost = oldCost1 = dataGridView1.Rows[rowIndex].Cells["Цена"].Value.ToString();
            if ((Costs = dataGridView1.Rows[rowIndex].Cells["Стоимость"].Value.ToString().Split('\n')).Length == 2)
            {
                realCost = newCost1 = Costs[1];
            }
            if (dataGridView1.Rows[rowIndex].Cells["Скидка"].Value.ToString() != "")
                discountInRubles = (Convert.ToInt32(oldCost1) - Convert.ToInt32(realCost)).ToString();

            if (row == null)
            {
                Basket.GetBasket.Rows.Add(dataGridView1.Rows[rowIndex].Cells["Артикул"].Value.ToString(),
                    dataGridView1.Rows[rowIndex].Cells["Наименование"].Value.ToString(), "1", realCost, newCost1, oldCost1, dataGridView1.Rows[rowIndex].Cells["image"].Value.ToString(),
                    dataGridView1.Rows[rowIndex].Cells["Скидка"].Value.ToString(), discountInRubles.ToString());
            }
            else
            {
                try
                {
                    row["Количество"] = (Convert.ToInt32(row["Количество"]) + 1).ToString();
                    row["Стоимость"] = (Convert.ToInt32(row["Стоимость"].ToString()) + Convert.ToInt32(realCost)).ToString();
                    row["Стоимость без скидки"] = (Convert.ToInt32(row["Стоимость без скидки"].ToString()) + Convert.ToInt32(oldCost1)).ToString();
                    if (dataGridView1.Rows[rowIndex].Cells["Скидка"].Value.ToString() != "")
                    {
                        row["Скидка в рублях"] = (Convert.ToInt32(row["Скидка в рублях"].ToString()) + Convert.ToInt32(discountInRubles)).ToString();
                        row["Стоимость со скидкой"] = (Convert.ToInt32(row["Стоимость со скидкой"].ToString()) + Convert.ToInt32(newCost1)).ToString();
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Basket.GetBasket.Rows.Count == 0)
            {
                MessageBox.Show("В вашей корзине пока ничего нет, добавить туда товары и можете перейти к просмотру", "Внимание", MessageBoxButtons.OK);
                return;
            }
            this.Hide();
            BasketShow q = new BasketShow(rowIndex, textSearch.Text, comboBoxFilter.Text, comboBoxOrderBy.Text, numberPage);
            q.ShowDialog();
        }
    }
}
