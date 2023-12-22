using System;
using System.IO;
using System.Windows.Forms;
using shop.Classes;
namespace shop.Forms
{
    public partial class RestoreData : Form
    {
        public RestoreData(string[] scriptsArray)
        {
            InitializeComponent();
            for(int i = 0; i < scriptsArray.Length; i++)
            comboBox1.Items.Add(Path.GetFileName(scriptsArray[i]));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main q = new Main();
            q.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Вы не выбрали файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadData.Restore(comboBox1.Text);
        }
    }
}
