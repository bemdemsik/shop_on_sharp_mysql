using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using shop.Classes;

namespace shop.Forms
{
    public partial class User : Form
    {
        string where = "";
        string request = "select id,fio as 'ФИО', login as 'Логин', passwd as 'Пароль', (select roleName from roleuser where id = idrole) as 'Роль', birthday as 'Дата рождения', telephone from user";
        string search = "";
        string orderBy = "";
        string filt = "";
        string oldSearch = "";
        string oldFilt = "";
        string oldOrderBy = "";
        int countPage = 0;
        int numberPage = 1;
        int oldNumberPage = -1;
        int rowIndex = 0;
        int oldNumberRowActive = -1;
        bool checkNewColumns = false;
        public User()
        {
            InitializeComponent();
        }
        public User(string where1)
        {
            where = where1;
            InitializeComponent();
        }
        public User(int numberRowActive1, string search1, string filt1, string orderby1, int numberActivePage1)
        {
            where = "";
            oldFilt = filt1;
            oldSearch = search1;
            oldOrderBy = orderby1;
            oldNumberPage = numberActivePage1;
            oldNumberRowActive = numberRowActive1;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main q = new Main();
            q.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            try
            {
                int primaryKey = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value.ToString());
                string dasf = dataGridView1.Columns[e.ColumnIndex].Name;
            }
            catch
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Удалить")
            {
                if (MessageBox.Show("Вы уверены что хотите удалить эту запись?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Request.RequestData("delete from user where id='" + dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'"))
                    {
                        MessageBox.Show("Запись успешна удалена", "Ура", MessageBoxButtons.OK);
                        ShowUsers();
                        ShowFIOAndTelephone();
                    }
                }
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Изменить")
            {
                this.Hide();
                UserAddAndChange q = new UserAddAndChange(dataGridView1.Rows[e.RowIndex], e.RowIndex, textSearch.Text, comboBoxFilter.Text, comboBoxOrderBy.Text, numberPage);
                q.ShowDialog();
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            comboBoxFilter.Items.Add("Все роли");
            comboBoxFilter.Items.AddRange(DataFillArray.Read("select roleName from roleuser", 0));
            comboBoxOrderBy.Items.Add("");
            comboBoxOrderBy.Items.Add("Возрастанию");
            comboBoxOrderBy.Items.Add("Убыванию");
            if (oldNumberPage != -1)
            {
                oldParameters();
                numberPage = oldNumberPage;
            }
            ShowUsers();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowFIOAndTelephone();
            dataGridView1.Columns["ФИО"].Width = 250;
            if (oldNumberRowActive != -1)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[oldNumberRowActive].Selected = true;
            }
            UI();
            where = "";
        }
        private void AddColumnsInDataGridView()
        {
            DataGridViewTextBoxColumn telephone = new DataGridViewTextBoxColumn();
            telephone.Name = "Телефон";
            dataGridView1.Columns.Add(telephone);
            if (UserInformation.GetRole == "Администратор")
            {
                DataGridViewButtonColumn change = new DataGridViewButtonColumn();
                change.UseColumnTextForButtonValue = true;
                change.Name = "Изменение";
                change.Text = "Изменить";
                change.Width = 160;
                dataGridView1.Columns.Add(change);
                DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
                delete.UseColumnTextForButtonValue = true;
                delete.Name = "Удаление";
                delete.Text = "Удалить";
                delete.Width = 160;
                dataGridView1.Columns.Add(delete);
            }
            else
            {
                button2.Visible = false;
            }
            checkNewColumns = true;
        }
        private void oldParameters()
        {
            textSearch.Text = oldSearch;
            comboBoxOrderBy.Text = oldOrderBy;
            comboBoxFilter.Text = oldFilt;
        }
        private void ShowUsers()
        {
            labelAllCountDataRows.Text = ReadOneStr.Read("select count(*) from user " + filt)[0];
            countPage = Convert.ToInt32(Math.Ceiling(Convert.ToInt32(labelAllCountDataRows.Text) / 10.0));
            dataGridView1.DataSource = LoadData.Table(request + filt + search + orderBy + where + " limit " + ((numberPage - 1) * 10) + ", 10");
            try
            {
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["Логин"].Visible = false;
                dataGridView1.Columns["Пароль"].Visible = false;
                dataGridView1.Columns["telephone"].Visible = false;
            }
            catch
            {
                return;
            }
        }
        private void ShowFIOAndTelephone()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string[] fio = row.Cells["ФИО"].Value.ToString().Split(' ');
                string fio1 = "";
                try
                {
                    fio1 = fio[0];
                    fio1 += " " + fio[1].ToCharArray()[0].ToString() + "****";
                    fio1 += " " + fio[2].ToCharArray()[0].ToString() + "****";
                    row.Cells["ФИО"].Value = fio1;
                }
                catch
                {
                    row.Cells["ФИО"].Value = fio1;
                }

                if (row.Cells["telephone"].Value.ToString() != "")
                {
                    string[] telephon = row.Cells["telephone"].Value.ToString().Split('-');
                    row.Cells["Телефон"].Value = telephon[0] + "-**-**";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserAddAndChange q = new UserAddAndChange();
            q.ShowDialog();
        }
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[0-9]|[\b]"))
                e.Handled = true;
        }

        private void textFIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();
            if (!Regex.IsMatch(Symbol, @"[а-яА-Я]|[\b]|[^\S\r\n]|[.]"))
                e.Handled = true;
        }

        private void comboBoxOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrderBy.Text == "")
                orderBy = "";
            else if (comboBoxOrderBy.Text == "Возрастанию")
                orderBy = " order by birthday";
            else
                orderBy = " order by birthday desc";
            if (search != "")
            {
                orderBy = orderBy.Replace("order by ", ",");
            }
            numberPage = 1;
            ShowUsers();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowFIOAndTelephone();
            UI();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            search = " order by case when fio like '" + textSearch.Text + "%' then 1 when fio like '%" + textSearch.Text + "%' then 2 else 3 end";
            if (textSearch.Text == "")
            {
                if (orderBy != "")
                {
                    if (comboBoxOrderBy.Text == "")
                        orderBy = "";
                    else if (comboBoxOrderBy.Text == "Возрастанию")
                        orderBy = " order by birthday ";
                    else
                        orderBy = " order by birthday desc ";
                }
                search = "";
            }
            else
            {
                if (orderBy != "")
                {
                    if (comboBoxOrderBy.Text == "")
                        orderBy = "";
                    else if (comboBoxOrderBy.Text == "Возрастанию")
                        orderBy = " ,birthday ";
                    else
                        orderBy = " ,birthday desc ";
                }
            }
            numberPage = 1;
            ShowUsers();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowFIOAndTelephone();
            UI();
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

        private void nextlabel_Click(object sender, EventArgs e)
        {
            numberPage += 1;
            ShowUsers();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowFIOAndTelephone();
            UI();
        }

        private void backlabel_Click(object sender, EventArgs e)
        {
            numberPage -= 1;
            ShowUsers();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowFIOAndTelephone();
            UI();
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            filt = " where idrole=(select id from roleuser where roleName='" + comboBoxFilter.Text + "')";
            if (comboBoxFilter.Text == "Все роли")
                filt = "";
            numberPage = 1;
            ShowUsers();
            if (!checkNewColumns)
                AddColumnsInDataGridView();
            ShowFIOAndTelephone();
            UI();
        }
    }
}
