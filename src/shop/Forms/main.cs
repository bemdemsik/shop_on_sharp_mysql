using System;
using System.Windows.Forms;
using shop.Classes;
using System.IO;
namespace shop.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            User q = new User();
            q.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadData.Backup();
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Product q = new Product();
            q.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Basket.GetBasket.Rows.Clear();
            this.Hide();
            Autorization q = new Autorization();
            q.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(UserInformation.GetRole != "Менеджер" && UserInformation.GetRole != "Администратор")
            {
                button1.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
            }
            if(UserInformation.GetRole == "Менеджер")
            {
                button1.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowOrders q = new ShowOrders();
            q.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportAndExportData q = new ImportAndExportData();
            q.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] scriptsArray = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\scripts\\", "*.sql");
            if (scriptsArray.Length == 0)
            {
                MessageBox.Show("Вы не можите восстановить базу данных, так как не найдено ни одного зарезервированного скрипта для восстановления", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Hide();
            RestoreData q = new RestoreData(scriptsArray);
            q.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadData.Backup();
            MessageBox.Show("Резервное копирование выполнено успешно","Резервное копирование",MessageBoxButtons.OK);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddAndDeleteDiscount q = new AddAndDeleteDiscount();
            q.ShowDialog();
        }
    }
}
