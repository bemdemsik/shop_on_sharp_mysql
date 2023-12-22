using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using shop.Classes;
using System.IO;
namespace shop.Forms
{
    public partial class BasketShow : Form
    {
        Random rdm = new Random();      
        string[] queryStrings = new string[3];
        public static string numberOrder;
        public static int dayDelivery = 6;
        DataRow row;
        string oldSearch = "";
        string oldFilt = "";
        string oldOrderBy = "";
        string picupPoint = "";
        string clientFio = "";
        int numberPage = 1;
        int oldNumberRowActive = 0;
        int code = 0;
        public BasketShow()
        {
            InitializeComponent();
        }
        public BasketShow(string picupPoint1)
        {
            picupPoint = picupPoint1;
            InitializeComponent();
        }
        public BasketShow(string clientFio1, string picupPoint1)
        {
            picupPoint = picupPoint1;
            clientFio = clientFio1;
            InitializeComponent();
        }
        public BasketShow(int numberRowActive, string search, string filt, string orderby, int numberActivePage)
        {
            oldSearch = search;
            oldFilt = filt;
            oldOrderBy = orderby;
            numberPage = numberActivePage;
            oldNumberRowActive = numberRowActive;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product q = new Product(oldNumberRowActive, oldSearch, oldFilt, oldOrderBy, numberPage);
            q.ShowDialog();
        }
        private void ShowBasket()
        {
            dataGridView1.DataSource = Basket.GetBasket;
            try
            {
                dataGridView1.Columns["Стоимость без скидки"].Visible = false;
                dataGridView1.Columns["Стоимость со скидкой"].Visible = false;
                dataGridView1.Columns["image"].Visible = false;
                dataGridView1.Columns["Скидка"].Visible = false;
                dataGridView1.Columns["Скидка в рублях"].Visible = false;
            }
            catch
            {
                return;
            }
        }
        private void UpdateCostOrders()
        {
            foreach (DataGridViewRow row1 in dataGridView1.Rows)
            {
                if (labelCostDiscount.Text == "")
                {
                    labelCostDiscount.Text = (Convert.ToInt32(row1.Cells["Стоимость"].Value.ToString())).ToString();
                }
                else
                {
                    labelCostDiscount.Text = (Convert.ToInt32(labelCostDiscount.Text) + Convert.ToInt32(row1.Cells["Стоимость"].Value.ToString())).ToString();
                }

                if (labelCostOrder.Text == "")
                {
                    labelCostOrder.Text = (Convert.ToInt32(row1.Cells["Стоимость без скидки"].Value.ToString())).ToString();
                }
                else
                {
                    labelCostOrder.Text = (Convert.ToInt32(labelCostOrder.Text) + Convert.ToInt32(row1.Cells["Стоимость без скидки"].Value.ToString())).ToString();
                }
            }
            labelSumDiscount.Text = (Convert.ToInt32(labelCostOrder.Text) - Convert.ToInt32(labelCostDiscount.Text)).ToString();
        }
        private void AddColumnsInDataGridView()
        {
            DataGridViewImageColumn image = new DataGridViewImageColumn();
            image.ImageLayout = DataGridViewImageCellLayout.Zoom;
            image.Name = "Картинка";
            dataGridView1.Columns.Add(image);
            DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
            delete.UseColumnTextForButtonValue = true;
            delete.Name = "Удаление";
            delete.Text = "Удалить";
            dataGridView1.Columns.Add(delete);
        }
        private void ShowImage()
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
            }
        }
        private void BasketShow_Load(object sender, EventArgs e)
        {
            ShowBasket();
            AddColumnsInDataGridView();
            ShowImage();
            UpdateCostOrders();
            comboBoxPicupPoint.Items.AddRange(DataFillArray.Read("select pickuppointName from pickuppoint", 0));
            if (picupPoint != "")
            {
                comboBoxPicupPoint.Text = picupPoint;
            }
            if (UserInformation.GetRole == "Администратор" || UserInformation.GetRole == "Менеджер")
            {
                comboBox1.Items.AddRange(DataFillArray.Read("select fio from user", 0));
                if(clientFio != "")
                {
                        comboBox1.Text = clientFio;
                }
            }
            else
            {
                label5.Visible = false;
                comboBox1.Visible = false;
            }
            if(UserInformation.GetRole != "Не авторизованный клиент")
            {
                labelFIO.Visible = false;
                textBoxFIO.Visible = false;
            }
            else
            {
                textBoxFIO.Text = clientFio;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckData())
            {
                return;
            }
            FormationsquEstions();
            if (OrderProduct.RequestData(queryStrings))
            {
                MessageBox.Show("Заказ оформлен", "Ура", MessageBoxButtons.OK);
                if (MessageBox.Show("Хотите сделать чек заказа?", "Чек заказа", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ShowCheque();
                }
                Basket.GetBasket.Rows.Clear();
                comboBoxPicupPoint.Items.Clear();
                comboBoxPicupPoint.Items.AddRange(DataFillArray.Read("select pickuppointName from pickuppoint", 0));
                comboBoxPicupPoint.SelectedIndex = -1;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(DataFillArray.Read("select fio from user", 0));
                comboBox1.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("При заказе возникли ошибки, попробуйте позже", "Внимание", MessageBoxButtons.OK);
            }
        }
        private void FormationsquEstions()
        {
            code = rdm.Next(100, 999);
            queryStrings = new string[2];
            if (UserInformation.GetRole == "Менеджер" || UserInformation.GetRole == "Администратор")
                queryStrings[0] = "insert into orders (iduser, order_date, date_receiving, costOrder, `code`,idstaff, idpickuppoint, idstatus) values((select min(id) from user where fio='" + comboBox1.Text + "'),CURDATE(),'" + DateTime.Now.AddDays(dayDelivery).ToString("yyyy-MM-dd") + "','" + labelCostDiscount.Text + "'," + code + ",(select min(id) from user where idrole=(select id from roleuser where roleName='" + UserInformation.GetRole + "') and fio='" + UserInformation.GetFIO + "'),(select min(id) from pickuppoint where pickuppointName='" + comboBoxPicupPoint.Text + "'),(select id from statusorder where statusTitle='Ожидается'))";
            else
                queryStrings[0] = "insert into orders (iduser, order_date, date_receiving, costOrder, `code`, idpickuppoint, idstatus) values((select min(id) from user where fio='" + UserInformation.GetFIO + "'),CURDATE(),'" + DateTime.Now.AddDays(dayDelivery).ToString("yyyy-MM-dd") + "','" + labelCostDiscount.Text + "'," + code + ",(select min(id) from pickuppoint where pickuppointName='" + comboBoxPicupPoint.Text + "'),(select id from statusorder where statusTitle='Ожидается'))";
            foreach (DataGridViewRow row1 in dataGridView1.Rows)
            {
                if (queryStrings[1] != null)
                {
                    queryStrings[1] += ",";
                }
                queryStrings[1] += "((select last_insert_id()),'" + row1.Cells["Артикул"].Value.ToString() + "'," + row1.Cells["Количество"].Value.ToString() + ",'" + row1.Cells["Стоимость"].Value.ToString() + "')";
                Array.Resize(ref queryStrings, queryStrings.Length + 1);
                queryStrings[queryStrings.Length - 1] = "update product set countStock=countStock-" + row1.Cells["Количество"].Value.ToString() + " where articule='" + row1.Cells["Артикул"].Value.ToString() + "'";
            }
            queryStrings[1] = "insert into ordersstructure (idorders,idproduct,countProduct,costProduct) values " + queryStrings[1];
        }
        private bool CheckData()
        {
            if (comboBox1.Visible && comboBox1.Text == "")
            {
                MessageBox.Show("Вы не выбрали получателя", "Внимание", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                if (comboBox1.Text != "")
                {
                    if (DataFillArray.Read("select * from user where fio='" + comboBox1.Text + "'", 0).Length == 0)
                    {
                        if(MessageBox.Show("Получаетль еще не зарегистрирован. Хотите внести о клиенте более подробную информацию?","Внимание",MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Hide();
                            UserAddAndChange q = new UserAddAndChange(comboBox1.Text, comboBoxPicupPoint.Text);
                            q.ShowDialog();
                            return false;
                        }
                        else
                        {
                            if (!Request.RequestData("insert into user (fio, idrole) values('" + comboBox1.Text + "',(select id from roleuser where roleName='Клиент'))"))
                            {
                                MessageBox.Show("При заказе возникли ошибки попробуйте позже", "Внимание", MessageBoxButtons.OK);
                                return false;
                            }
                        }
                    }
                }
            }
            if(textBoxFIO.Visible && textBoxFIO.Text == "")
            {
                MessageBox.Show("Вы не указали ФИО для оформления заказа", "Внимание", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                if (textBoxFIO.Visible)
                {
                    if (!Request.RequestData("insert into user (fio, idrole) values('" + textBoxFIO.Text + "',(select id from roleuser where roleName='Клиент'))"))
                    {
                        MessageBox.Show("При заказе возникли ошибки попробуйте позже", "Внимание", MessageBoxButtons.OK);
                        return false;
                    }
                    UserInformation.GetFIO = textBoxFIO.Text;
                    if (MessageBox.Show("Вы еще не зарегистрированны в приложении. Хотите это сделать прямо сейчас?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Hide();
                        UserAddAndChange q = new UserAddAndChange(textBoxFIO.Text, comboBoxPicupPoint.Text);
                        q.ShowDialog();
                        return false;
                    }
                }
            }
            if (Basket.GetBasket.Rows.Count == 0)
            {
                MessageBox.Show("Вам нечего заказывать", "Внимание", MessageBoxButtons.OK);
                return false;
            }

            if (comboBoxPicupPoint.Text == "")
            {
                MessageBox.Show("Вы не указали пункт выдачи", "Внимание", MessageBoxButtons.OK);
                return false;
            }
            if (!DataFillArray.Read("select pickuppointName from pickuppoint", 0).Contains(comboBoxPicupPoint.Text))
            {
                if (!Request.RequestData("insert into pickuppoint (pickuppointName) values('" + comboBoxPicupPoint.Text + "')"))
                {
                    MessageBox.Show("Не получилось найти данный пункт выдачи", "Внимание", MessageBoxButtons.OK);
                    return false;
                }
            }
            try
            {
                row = Basket.GetBasket.Select("Количество>2").FirstOrDefault();
                if (row != null)
                {
                    dayDelivery = 3;
                }
            }
            catch
            {
                dayDelivery = 6;
            }
            return true;
        }
        private void ShowCheque()
        {
            string[] data;
            string telephone = "";
            if (comboBox1.Text != "")
            {
                data = DataFillArray.Read("select telephone from user where fio='" + comboBox1.Text + "'", 0);
                if(data.Length != 0 && data[0] != null)
                {
                    telephone = ",тел. " + data[0];
                }
            }
            numberOrder = ReadOneStr.Read("select max(id) from orders")[0];
            Cheque.CreateNewCheque();
            Cheque.AddNewParagraphsCenter("Организация Мой магазин", 12, 0);
            Cheque.AddNewParagraphsCenter("Заказ №" + numberOrder + " от " + DateTime.Now.ToString("yyyy-MM-dd"), 16, 1);
            if(UserInformation.GetRole == "Не авторизованный клиент")
            {
                Cheque.AddNewParagraphsLeft("Покупатель: " + UserInformation.GetFIO + telephone, 14, 0);
            }
            else
            {
                Cheque.AddNewParagraphsLeft("Покупатель: " + comboBox1.Text + telephone, 14, 0);
            }
            Cheque.AddTable();
            Cheque.RangeCellsTable();
            Cheque.AddNewParagraphsLeft("Код для получения заказа: " + code.ToString(), 14, 1);
            Cheque.AddNewParagraphsLeft("Пункт выдачи: " + comboBoxPicupPoint.Text, 14, 0);
            if(comboBox1.Text != "")
            {
                Cheque.AddNewParagraphsLeft("Подпись покупателя___________________" + comboBox1.Text, 14, 0);
                Cheque.AddNewParagraphsLeft("Подпись сотрудника___________________" + UserInformation.GetFIO, 14, 0);
            }
            else
            {
                Cheque.AddNewParagraphsLeft("Подпись покупателя___________________" + UserInformation.GetFIO, 14, 0);
            }
            Cheque.SaveCheque();
            Cheque.Vis();
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
                if (MessageBox.Show("Вы уверены что хотите удалить эту запись из корзины?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Basket.GetBasket.Rows.Remove(Basket.GetBasket.Select("Артикул='" + dataGridView1.Rows[e.RowIndex].Cells["Артикул"].Value.ToString() + "'").FirstOrDefault());
                    ShowBasket();
                    UpdateCostOrders();
                }
            }
        }
        private void fioKeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[а-яА-Я]|[\b]|[^\S\r\n]|[.]"))
                e.Handled = true;
        }
        private void ru_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
        }
    }
}
