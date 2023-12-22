using System;
using System.Windows.Forms;
using shop.Classes;
namespace shop.Forms
{
    public partial class Autorization : Form
    {
        string capcha = "";
        int secondsCount = 10;
        public Autorization()
        {
            InitializeComponent();
            textLogin.Text = "admin";
            textPasswd.Text = "admin";
            groupBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textLogin.Text == "" || textPasswd.Text == "")
            {
                MessageBox.Show("Вы указали не все данные", "Внимание", MessageBoxButtons.OK);
                return;
            }
            string[] pwdAndRoleAndFio = ReadOneStr.Read("select passwd,(select roleName from roleuser where id=idrole),fio,telephone from user where login = '" + textLogin.Text + "'");
            if (groupBox1.Visible)
            {
                if (textBox3.Text != capcha)
                {
                    MessageBox.Show("Вы ввели неверные символы", "Внимание", MessageBoxButtons.OK);
                    StartTimerEnebledEnter();
                    GenereteCapcha();
                    return;
                }
            }
            if (pwdAndRoleAndFio.Length == 0 || pwdAndRoleAndFio[0] != textPasswd.Text)
            {
                MessageBox.Show("Вы ввели неверные данные", "Внимание", MessageBoxButtons.OK);
                if (groupBox1.Visible)
                    StartTimerEnebledEnter();
                groupBox1.Visible = true;
                GenereteCapcha();
                return;
            }
            UserInformation.GetRole = pwdAndRoleAndFio[1];
            UserInformation.GetFIO = pwdAndRoleAndFio[2];
            UserInformation.GetTelephone = pwdAndRoleAndFio[3];
            this.Hide();
            if (UserInformation.GetRole == "Клиент")
            {
                Product q = new Product();
                q.ShowDialog();
            }
            else
            {
                Main q = new Main();
                q.ShowDialog();
            }
        }
        private void StartTimerEnebledEnter()
        {
            secondsCount = 10;
            textBox3.Clear();
            button1.Enabled = false;
            label10.Enabled = false;
            timer1.Start();
            timer1.Interval = 1000;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void GenereteCapcha()
        {
            string symbol = "QWERTYUIOPLKJHGFDSAZXCVBNMmnbvcxzasdhfjgklpoiuqywter";
            Random random = new Random();
            capcha += label4.Text = symbol[random.Next(0, symbol.Length - 1)].ToString();
            capcha += label5.Text = symbol[random.Next(0, symbol.Length - 1)].ToString();
            capcha += label6.Text = symbol[random.Next(0, symbol.Length - 1)].ToString();
            capcha += label7.Text = symbol[random.Next(0, symbol.Length - 1)].ToString();
            capcha += label8.Text = symbol[random.Next(0, symbol.Length - 1)].ToString();
            capcha += label9.Text = symbol[random.Next(0, symbol.Length - 1)].ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            UserInformation.GetRole = "Не авторизованный клиент";
            UserInformation.GetFIO = "";
            UserInformation.GetTelephone = "";
            this.Hide();
            Product q = new Product();
            q.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Text = secondsCount.ToString();
            secondsCount--;
            if (secondsCount == -1)
            {
                button1.Enabled = true;
                label10.Enabled = true;
                button1.Text = "Вход";
                timer1.Stop();
            }
        }
    }
}
