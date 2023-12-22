using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using shop.Classes;
namespace shop.Forms
{
    public partial class AddAndDeleteDiscount : Form
    {
        public AddAndDeleteDiscount()
        {
            InitializeComponent();
        }

        private void AddAndDeleteDiscount_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.AddRange(DataFillArray.Read("select categoryName from categoryproduct",0));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main q = new Main();
            q.ShowDialog();
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBoxDiscount.Text = ReadOneStr.Read("select categoryDiscount from categoryproduct where categoryName='" + comboBoxCategory.Text + "'")[0];
            }
            catch
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBoxCategory.Text == "")
            {
                MessageBox.Show("Вы не выбрали категорию","Внимание",MessageBoxButtons.OK);
                return;
            }
            if (!Request.RequestData("update categoryproduct set categoryDiscount="+textBoxDiscount.Text+" where categoryName='" + comboBoxCategory.Text + "'"))
            {
                MessageBox.Show("При изменении скидки возникли ошибки, попробуйте позже", "Внимание", MessageBoxButtons.OK);
                return;
            }
            MessageBox.Show("Вы добавили скидку для категории", "Ура", MessageBoxButtons.OK);
            comboBoxCategory.SelectedIndex = -1;
            textBoxDiscount.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.Text == "")
            {
                MessageBox.Show("Вы не выбрали категорию", "Внимание", MessageBoxButtons.OK);
                return;
            }
            if(!Request.RequestData("update categoryproduct set categoryDiscount=0 where categoryName='" + comboBoxCategory.Text + "'"))
            {
                MessageBox.Show("При изменении скидки возникли ошибки, попробуйте позже", "Внимание", MessageBoxButtons.OK);
                return;
            }
            MessageBox.Show("Вы удалили скидку для категории", "Ура", MessageBoxButtons.OK);
            comboBoxCategory.SelectedIndex = -1;
            textBoxDiscount.Text = "";
        }

        private void textBoxDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[0-9]|[\b]"))
                e.Handled = true;
        }
    }
}
