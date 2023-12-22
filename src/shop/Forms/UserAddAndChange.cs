using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using shop.Classes;
namespace shop.Forms
{
    public partial class UserAddAndChange : Form
    {
        string request = "select id,fio as 'ФИО', login as 'Логин', passwd as 'Пароль', (select roleName from roleuser where id = idrole) as 'Роль', birthday as 'Дата рождение', telephone from user";
        string primaryKey = "";
        string telephone = "";
        string date = "";
        string oldSearch = "";
        string oldFilt = "";
        string oldOrderBy = "";
        string picupPoint = "";
        int numberPage = 1;
        int oldNumberRowActive = 0;
        public UserAddAndChange()
        {
            InitializeComponent();
            button2.Text = "Добавить";
        }
        public UserAddAndChange(string pickupPoint1)
        {
            picupPoint = pickupPoint1;
            InitializeComponent();
            this.Text = "Регистрация клиента";
        }
        public UserAddAndChange(string clientFio1, string pickupPoint1)
        {
            picupPoint = pickupPoint1;
            InitializeComponent();
            textFIO.Text = clientFio1;
            this.Text = "Регистрация клиента";
        }
        public UserAddAndChange(DataGridViewRow row, int numberRowActive, string search,string oldfilt1, string orderby, int numberActivePage)
        {
            oldSearch = search;
            oldFilt = oldfilt1;
            oldOrderBy = orderby;
            numberPage = numberActivePage;
            oldNumberRowActive = numberRowActive;
            primaryKey = row.Cells["id"].Value.ToString();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(button1.Text == "К заказу")
            {
                BasketShow q;
                if(UserInformation.GetRole == "Менеджер" || UserInformation.GetRole == "Администратор")
                {
                    q = new BasketShow(textFIO.Text,picupPoint);
                }
                else
                {
                    q = new BasketShow(picupPoint);
                }
                q.ShowDialog();
            }
            else
            {
                User q;
                if (button2.Text == "Сохранить")
                {
                    q = new User(oldNumberRowActive, oldSearch, oldFilt, oldOrderBy, numberPage);
                }
                else
                {
                    q = new User(" order by id desc");
                }
                q.ShowDialog();
            }
        }
        private bool CheckData()
        {
            if (maskedTextBox1.Text.Split('_', ' ').Length != 9 && maskedTextBox1.Text.Length != 16 || maskedTextBox1.Text.Split('_', ' ').Length != 9 && maskedTextBox1.Text.Split('_', ' ').Length != 1)
            {
                MessageBox.Show("Вы неверно ввели телефон", "Внимание", MessageBoxButtons.OK);
                return false;
            }
            if (textFIO.Text == "" || textLogin.Text == "" || textPasswd.Text == "" || comboBoxRole.Text == "")
            {
                MessageBox.Show("Вы заполнили не все обязательные поля", "Внимание", MessageBoxButtons.OK);
                return false;
            }

            string cheskLogin = "select * from user where login = '" + textLogin.Text + "'";
            if (button2.Text == "Сохранить")
            {
                cheskLogin += " and id != " + primaryKey;
            }

            if (ReadOneStr.Read(cheskLogin).Length > 0)
            {
                MessageBox.Show("Такой логин уже существует", "Внимание", MessageBoxButtons.OK);
                textLogin.Clear();
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(button1.Text != "К заказу")
            {
                if (!CheckData())
                {
                    return;
                }
            }
            else
            {
                if(textFIO.Text == "")
                {
                    MessageBox.Show("Вы не указали ФИО", "Внимание", MessageBoxButtons.OK);
                    return;
                }
            }

            if (button2.Text == "Сохранить")
            {
                request = "update user set fio='" + textFIO.Text + "',passwd='" + textPasswd.Text + "',login='" + textLogin.Text + "',idrole=(select id from roleuser where roleName='" + comboBoxRole.Text + "'),birthday='" + date + "',telephone='" + telephone + "' where id=" + primaryKey;
            }
            else
            {
                request = "insert into user(fio,login,passwd,idrole,birthday,telephone) values('" + textFIO.Text + "','" + textLogin.Text + "','" + textPasswd.Text + "',(select id from roleuser where roleName='" + comboBoxRole.Text + "'),'" + date + "','" + telephone + "')";
            }

            if (Request.RequestData(request))
            {
                if(button1.Text == "К заказу")
                {
                    if(UserInformation.GetRole == "Не авторизованный клиент")
                    {
                        UserInformation.GetFIO = textFIO.Text;
                        UserInformation.GetTelephone = telephone;
                    }
                    if (button2.Text != "Сохранить")
                    {
                        if (MessageBox.Show("Теперь вы можете вернуться к заказу товаров. Сделать это прямо сейчас?", "Заказ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.Hide();
                            BasketShow q;
                                q = new BasketShow(textFIO.Text, picupPoint);
                            q.ShowDialog();
                            return;
                        }
                        button2.Text = "Сохранить";
                    }
                }
                MessageBox.Show("Запрос выполнен успешно", "Ура", MessageBoxButtons.OK);
                if (button2.Text == "Добавить")
                {
                    ClearBox();
                }
            }
            else
            {
                MessageBox.Show("При запросе возникли ошибки, попрубуйте позже", "Внимание", MessageBoxButtons.OK);
            }
        }
        private void ClearBox()
        {
            textFIO.Clear();
            textLogin.Clear();
            textPasswd.Clear();
            comboBoxRole.SelectedIndex = -1;
            maskedTextBox1.Clear();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string symbol = "QWERTYUIOPLKJHGFDSAZXCVBNMmnbvcxzasdhfjgklpoiuqywter";
            textLogin.Text = "login";
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                textLogin.Text += symbol[random.Next(0, symbol.Length)];
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textPasswd.Text = "";
            string symbol = "QWERTYUIOPLKJHGFDSAZXCVBNMmnbvcxzasdhfjgklpoiuqywter1234567890'[}.,%$#@!&?*()|:;";
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                textPasswd.Text += symbol[random.Next(0, symbol.Length)];
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Replace(" ", "").Length != 16)
            {
                telephone = "";
            }
            else
            {
                telephone = maskedTextBox1.Text;
            }
        }

        private void UserAddAndChange_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "''";
            comboBoxRole.Items.AddRange(DataFillArray.Read("select * from roleuser", 1));
            if(this.Text == "Регистрация клиента")
            {
                button1.Text = "К заказу";
                button2.Text = "Записать";
                comboBoxRole.Text = "Клиент";
                if (UserInformation.GetFIO == "" || UserInformation.GetRole == "Менеджер")
                {
                    label6.Visible = false;
                    comboBoxRole.Visible = false;
                }
                return;
            }
            if (button2.Text == "Добавить" || UserInformation.GetFIO == "")
            {
                comboBoxRole.Text = "Клиент";
                return;
            }
            try
            {
                string[] dataUser = ReadOneStr.Read(request + " where id=" + primaryKey);
                textFIO.Text = dataUser[1];
                textLogin.Text = dataUser[2];
                textPasswd.Text = dataUser[3];
                comboBoxRole.Text = dataUser[4];
                dateTimePicker1.Text = dataUser[5];
                maskedTextBox1.Text = dataUser[6];
            }
            catch
            {
                return;
            }
        }
        private void fioKeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[а-яА-Я]|[\b]|[^\S\r\n]|[.]"))
                e.Handled = true;
        }
        private void loginKeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[a-zA-Z]|[\b]|[^\S\r\n]"))
                e.Handled = true;
        }
        private void passwdKeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[a-zA-Z]|[0-9]|[\b]|[^\S\r\n]"))
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
