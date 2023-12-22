using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using shop.Classes;
using System.IO;
namespace shop.Forms
{
    public partial class ImportAndExportData : Form
    {
        public ImportAndExportData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main q = new Main();
            q.ShowDialog();
        }

        private void ImportAndExportData_Load(object sender, EventArgs e)
        {
            comboBoxTableName.Items.AddRange(DataFillArray.Read("SELECT table_name FROM information_schema.tables WHERE table_schema = 'db60'", 0));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBoxTableName.Text == "")
            {
                MessageBox.Show("Вы не выбрали таблицу","Внимание",MessageBoxButtons.OK);
                return;
            }
            DataTable tb = LoadData.Table("select * from " + comboBoxTableName.Text);
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\dataInCSV\\" + comboBoxTableName.Text + ".csv", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fs, Encoding.Unicode);
            for (int i = 1; i < tb.Columns.Count; i++)
            {
                writer.Write(tb.Columns[i].ColumnName);
                if (i != tb.Columns.Count - 1)
                    writer.Write(";");
            }
            writer.Write("\n");
            foreach (DataRow dataRow in tb.Rows)
            {
                writer.WriteLine(string.Join(";", dataRow.ItemArray));
            }
            writer.Close();
            MessageBox.Show("Выгружено " + tb.Rows.Count + " строк", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxTableName.Text == "")
            {
                MessageBox.Show("Вы не выбрали таблицу", "Внимание", MessageBoxButtons.OK);
                return;
            }
            StreamReader FILE = null;
            try
            {
                string request = "insert into " + comboBoxTableName.Text + "(";
                DataTable tb = LoadData.Table("select * from "+comboBoxTableName.Text);
                for (int i = 1; i < tb.Columns.Count; i++)
                {
                    request += tb.Columns[i];
                    if (i != tb.Columns.Count - 1)
                        request += ",";
                }
                request += ") values";
                string read = "";
                string[] array;
                FILE = new StreamReader(Directory.GetCurrentDirectory() + "\\dataInCSV\\" + comboBoxTableName.Text + ".csv");
                int row = 0;
                while ((read = FILE.ReadLine()) != null)
                {
                    if (row == 0)
                    {
                        row++;
                        continue;
                    }
                    if (row > 1)
                    {
                        request += ',';
                    }
                    array = read.Split(';');
                    request += "(";
                    for (int i = 1; i < array.Length; i++)
                    {
                        request += "'"+array[i]+"'";
                        if (i != array.Length -1)
                        {
                            request += ',';
                        }
                        else
                        {
                            request += ")";
                        }
                    }
                    row++;
                }
                if(Request.RequestData(request))
                MessageBox.Show("Импорт произведён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("При импорте возникли ошибки, попробуйте позже", "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FILE.Close();
        }
    }
}
