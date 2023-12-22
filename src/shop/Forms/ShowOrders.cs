using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using shop.Classes;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
namespace shop.Forms
{
    public partial class ShowOrders : Form
    {
        DataTable allStaff = new DataTable();
        DataTable orders = new DataTable();
        string request = "select id,(select fio from user where id =iduser) as 'Получатель',order_date as 'Дата заказа',date_receiving as 'Дата получения',costOrder as 'Стоимость',`code` as 'Код',(select fio from user where id=idstaff) as 'Сотрудник',(select pickuppointName from pickuppoint where id =idpickuppoint) as 'Пункт выдачи', (select statusTitle from statusorder where id=idstatus) as 'Статус заказа' from orders";
        string search = "";
        string orderBy = "";
        string filt = "";
        string oldSearch = "";
        string oldOrderBy = "";
        string startDate = "";
        string finishDate = "";
        string sDate = "";
        string poDate = "";
        string where = "";
        int countPage = 0;
        int numberPage = 1;
        int oldNumberPage = -1;
        int rowIndex = 0;
        int oldNumberRowActive = -1;
        bool checkClearCondition = false;
        public ShowOrders()
        {
            InitializeComponent();
        }
        public ShowOrders(int numberRowActive1, string search1, string startDate1, string finishDate1, string orderby1, int numberActivePage1)
        {
            startDate = startDate1;
            finishDate = finishDate1;
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
            if (!CheckGroupBoxVisible())
            {
                return;
            }
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
            {
                return;
            }
        }
        private void oldParameters()
        {
            textSearch.Text = oldSearch;
            comboBoxOrderBy.Text = oldOrderBy;
            if (startDate != "")
            {
                dateTimePickerStart.Text = startDate;
            }
            if (finishDate != "")
            {
                dateTimePickerFinish.Text = finishDate;
            }
        }
        private void ShowAllOrders()
        {
            labelAllCountDataRows.Text = ReadOneStr.Read("select count(*) from orders " + filt)[0];
            countPage = Convert.ToInt32(Math.Ceiling(Convert.ToInt32(labelAllCountDataRows.Text) / 10.0));
            dataGridView1.DataSource = LoadData.Table(request + filt + search + orderBy + " limit " + ((numberPage - 1) * 10) + ", 10");
            try
            {
                dataGridView1.Columns["id"].Visible = false;
            }
            catch
            {
                return;
            }
            UpdateColorAllRows();
            UpdateColorStatus();
        }
        private void UpdateColorStatus()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Статус заказа"].Value.ToString() == "Отменен")
                {
                    row.Cells["Статус заказа"].Style.BackColor = Color.Red;
                }
                else if (row.Cells["Статус заказа"].Value.ToString() == "Получен")
                {
                    row.Cells["Статус заказа"].Style.BackColor = Color.Green;
                }
                else
                {
                    row.Cells["Статус заказа"].Style.BackColor = Color.Yellow;
                }
            }
        }
        private void UpdateColorAllRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string[] productInOrder = DataFillArray.Read("select idproduct from ordersstructure where idorders = " + row.Cells["id"].Value.ToString(), 0);
                Color color = new Color();
                foreach (string check in productInOrder)
                {
                    if (ReadOneStr.Read("select * from product where articule='" + check + "' and countStock > 3").Length != 0)
                    {
                        color = Color.LightSeaGreen;
                    }
                    else if (ReadOneStr.Read("select * from product where articule='" + check + "' and countStock = 0").Length != 0)
                    {
                        color = Color.DarkOrange;
                        break;
                    }
                    else
                    {
                        color = Color.White;
                        break;
                    }
                }
                row.DefaultCellStyle.BackColor = color;
            }
        }
        private void comboBoxOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOrderBy.Text == "")
            {
                orderBy = "";
            }
            else if (comboBoxOrderBy.Text == "Возрастанию")
            {
                orderBy = " order by costOrder";
            }
            else
            {
                orderBy = " order by costOrder desc";
            }

            if (search != "")
            {
                orderBy = orderBy.Replace("order by ", ",");
            }
            numberPage = 1;
            ShowAllOrders();
            UI();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            search = " order by case when (select fio from user where id=iduser) like '" + textSearch.Text + "%' then 1 when (select fio from user where id=iduser) like '%" + textSearch.Text + "%' then 2 else 3 end";
            if (textSearch.Text == "")
            {
                if (orderBy != "")
                {
                    if (comboBoxOrderBy.Text == "")
                    {
                        orderBy = "";
                    }
                    else if (comboBoxOrderBy.Text == "Возрастанию")
                    {
                        orderBy = " order by costOrder ";
                    }
                    else
                    {
                        orderBy = " order by costOrder desc ";
                    }
                }
                search = "";
            }
            else
            {
                if (orderBy != "")
                {
                    if (comboBoxOrderBy.Text == "")
                    {
                        orderBy = "";
                    }
                    else if (comboBoxOrderBy.Text == "Возрастанию")
                    {
                        orderBy = " ,costOrder ";
                    }
                    else
                    {
                        orderBy = " ,costOrder desc ";
                    }
                }
            }
            numberPage = 1;
            ShowAllOrders();
            UI();
        }
        private void UI()
        {
            nextlabel.Enabled = true;
            backlabel.Enabled = true;
            if (numberPage == 1)
            {
                backlabel.Enabled = false;
            }
            if (numberPage == countPage)
            {
                nextlabel.Enabled = false;
            }
            label3.Text = numberPage + "/" + countPage;
        }

        private void nextlabel_Click(object sender, EventArgs e)
        {
            if (!CheckGroupBoxVisible())
            {
                return;
            }
            numberPage += 1;
            ShowAllOrders();
            UI();
        }

        private void backlabel_Click(object sender, EventArgs e)
        {
            if (!CheckGroupBoxVisible())
            {
                return;
            }
            numberPage -= 1;
            ShowAllOrders();
            UI();
        }

        private void просмотрСтруктурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowStructureOrder q = new ShowStructureOrder(dataGridView1.Rows[rowIndex], rowIndex, textSearch.Text, startDate, finishDate, comboBoxOrderBy.Text, numberPage);
            q.ShowDialog();
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (!CheckGroupBoxVisible())
            {
                return;
            }
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                rowIndex = e.RowIndex;
                contextMenuStrip1.Show(Cursor.Position);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            checkClearCondition = true;
            if (!CheckGroupBoxVisible())
            {
                return;
            }
            startDate = "";
            finishDate = "";
            dateTimePickerStart.CustomFormat = "''";
            dateTimePickerStart.Text = "";
            dateTimePickerFinish.MinDate = DateTime.Parse("2023-01-01");
            dateTimePickerFinish.CustomFormat = "''";
            dateTimePickerFinish.Text = "";
            comboBoxOrderBy.SelectedIndex = -1;
            textSearch.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (checkClearCondition)
            {
                filt = "";
            }
            else
            {
                dateTimePickerStart.CustomFormat = "yyyy-MM-dd";
                startDate = dateTimePickerStart.Text;
                dateTimePickerFinish.MinDate = dateTimePickerStart.Value.AddSeconds(-100);
                filt = " where order_date >= '" + startDate + "'";
                if (finishDate != "")
                {
                    filt = " where order_date >= '" + startDate + "' and order_date <= '" + finishDate + "'";
                }
            }
            numberPage = 1;
            ShowAllOrders();
            UI();
        }

        private void изменитьСтатусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            dateTimePicker2.Text = dataGridView1.Rows[rowIndex].Cells["Дата получения"].Value.ToString();
            dateTimePicker2.MinDate = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells["Дата заказа"].Value.ToString());
            comboBoxStatus.Text = dataGridView1.Rows[rowIndex].Cells["Статус заказа"].Value.ToString();
        }
        private void ru_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
        }
        private bool CheckGroupBoxVisible()
        {
            if (groupBox1.Visible || groupBox2.Visible)
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                return false;
            }
            return true;
        }
        private void ShowOrders_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            dateTimePickerStart.CustomFormat = "''";
            dateTimePickerFinish.CustomFormat = "''";
            dateTimePickerS.CustomFormat = "''";
            dateTimePickerPo.CustomFormat = "''";
            dateTimePickerStart.MaxDate = DateTime.Now;
            dateTimePickerS.MaxDate = DateTime.Now;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            comboBoxOrderBy.Items.Add("");
            comboBoxOrderBy.Items.Add("Возрастанию");
            comboBoxOrderBy.Items.Add("Убыванию");
            comboBoxStatus.Items.AddRange(DataFillArray.Read("select * from statusorder", 1));
            comboBoxStaff.Items.Add("");
            comboBoxStaff.Items.Add("По всем сотрудникам");
            comboBoxStaff.Items.AddRange(DataFillArray.Read("select * from user where idrole in (select id from roleuser where roleName ='Администратор' or roleName ='Менеджер')", 1));
            if (oldNumberPage != -1)
            {
                oldParameters();
                numberPage = oldNumberPage;
            }
            ShowAllOrders();
            if (oldNumberRowActive != -1)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[oldNumberRowActive].Selected = true;
            }
            dataGridView1.Columns["Получатель"].Width = 250;
            UI();
        }

        private void ShowOrders_Click(object sender, EventArgs e)
        {
            if (!CheckGroupBoxVisible())
            {
                return;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (!CheckGroupBoxVisible())
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBoxStatus.Text != "")
            {
                if (DataFillArray.Read("select * from statusorder where statusTitle= '" + comboBoxStatus.Text + "'", 1).Length == 0)
                {
                    if (!Request.RequestData("insert into statusorder(statusTitle) values('" + comboBoxStatus.Text + "')"))
                    {
                        MessageBox.Show("При изменении возникли ошибки, попробуйте позже", "Внимание", MessageBoxButtons.OK);
                        groupBox1.Visible = false;
                        return;
                    }
                    comboBoxStatus.Items.Add(comboBoxStatus.Text);
                }
            }
            if (!Request.RequestData("update orders set idstatus=(select id from statusorder where statusTitle='" + comboBoxStatus.Text + "'), date_receiving='" + dateTimePicker2.Text + "' where id=" + dataGridView1.Rows[rowIndex].Cells["id"].Value.ToString()))
            {
                MessageBox.Show("При изменении возникли ошибки, попробуйте позже", "Внимание", MessageBoxButtons.OK);
                groupBox1.Visible = false;
                return;
            }
            if (comboBoxStatus.Text != "")
            {
                dataGridView1.Rows[rowIndex].Cells["Статус заказа"].Value = comboBoxStatus.Text;
            }
            dataGridView1.Rows[rowIndex].Cells["Дата получения"].Value = dateTimePicker2.Text;
            groupBox1.Visible = false;
            UpdateColorStatus();
            comboBoxStatus.Text = "";
        }

        private void dateTimePickerFinish_ValueChanged(object sender, EventArgs e)
        {
            if (checkClearCondition)
            {
                checkClearCondition = false;
                filt = "";
            }
            else
            {
                dateTimePickerFinish.CustomFormat = "yyyy-MM-dd";
                finishDate = dateTimePickerFinish.Text;
                filt = " where order_date <= '" + finishDate + "'";
                if (startDate != "")
                {
                    filt = " where order_date <= '" + finishDate + "' and order_date >= '" + startDate + "'";
                }
            }
            numberPage = 1;
            ShowAllOrders();
            UI();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            sDate = "";
            poDate = "";
            dateTimePickerS.CustomFormat = "''";
            dateTimePickerPo.CustomFormat = "''";
            dateTimePickerS.MaxDate = DateTime.Now;
            comboBoxStaff.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string staff = "";
            if (sDate != "")
            {
                where = " where order_date >= '" + sDate + "'";
            }
            if (poDate != "")
            {
                where = " where order_date <= '" + poDate + "'";
                if (sDate != "")
                {
                    where = " where order_date >= '" + sDate + "' and order_date <= '" + poDate + "'";
                }
            }
            if (comboBoxStaff.Text != "")
            {
                if (comboBoxStaff.Text != "По всем сотрудникам")
                {
                    if (where != "")
                    {
                        where = where + " and idstaff in (select id from user where fio = '" + comboBoxStaff.Text + "')";
                    }
                    else
                    {
                        where = " where idstaff in (select id from user where fio = '" + comboBoxStaff.Text + "')";
                    }
                    allStaff = LoadData.Table("select fio from user where fio = '" + comboBoxStaff.Text + "'");
                    staff = " сотрудника " + comboBoxStaff.Text;
                }
                else
                {
                    if (where != "")
                    {
                        where = where + " and idstaff in (select id from user where idrole in (select id from roleuser where roleName ='Администратор' or roleName ='Менеджер'))";
                    }
                    else
                    {
                        where = " where idstaff in (select id from user where idrole in (select id from roleuser where roleName ='Администратор' or roleName ='Менеджер'))";
                    }
                    allStaff = LoadData.Table("select fio from user where idrole in (select id from roleuser where roleName ='Администратор' or roleName ='Менеджер')");
                    staff = " по всем сотрудникам";
                }
            }
            if (sDate != "")
            {
                sDate = " c " + sDate;
            }
            if (poDate != "")
            {
                poDate = " по " + poDate;
            }
            double itog = 0;
            orders = LoadData.Table(request + where);
            Word.Application application = new Word.Application();
            Word.Document document = application.Documents.Add();
            document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            document.PageSetup.TopMargin = application.InchesToPoints(0.3f);
            document.PageSetup.LeftMargin = application.InchesToPoints(0.3f);
            document.PageSetup.RightMargin = application.InchesToPoints(0.3f);
            document.PageSetup.BottomMargin = application.InchesToPoints(0.3f);

            Word.Paragraph Par = document.Paragraphs.Add();
            Par.Range.Font.Size = 18;
            Par.Range.Text = "Заказы " + sDate + poDate + staff;
            Par.Range.Bold = 1;
            Par.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            Par.Range.InsertParagraphAfter();
            Word.Paragraph Dat = document.Paragraphs.Add();
            Dat.Range.Font.Size = 14;
            Dat.Range.Text = "";
            Dat.Range.Bold = 0;
            Par.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Dat.Range.InsertParagraphAfter();
            if (allStaff.Rows.Count == 0)
            {
                Word.Paragraph tableParagraph = document.Paragraphs.Add();
                Word.Range tableRange = tableParagraph.Range;
                Word.Table paymentsTable = document.Tables.Add(tableRange, 1, 8);
                paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                Word.Range cellRange;
                cellRange = paymentsTable.Cell(1, 1).Range;
                cellRange.Text = "Получатель";
                cellRange = paymentsTable.Cell(1, 2).Range;
                cellRange.Text = "Дата заказа";
                cellRange = paymentsTable.Cell(1, 3).Range;
                cellRange.Text = "Дата получения";
                cellRange = paymentsTable.Cell(1, 4).Range;
                cellRange.Text = "Стоимость заказа";
                cellRange = paymentsTable.Cell(1, 5).Range;
                cellRange.Text = "Сотрудник";
                cellRange = paymentsTable.Cell(1, 6).Range;
                cellRange.Text = "Код";
                cellRange = paymentsTable.Cell(1, 7).Range;
                cellRange.Text = "Пункт выдачи";
                cellRange = paymentsTable.Cell(1, 8).Range;
                cellRange.Text = "Статус";
                paymentsTable.Rows[1].Range.Bold = 1;
                paymentsTable.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int y = 2;
                foreach (DataRow row in orders.Rows)
                {
                    paymentsTable.Rows.Add();
                    paymentsTable.Rows[y].Range.Bold = 0;
                    cellRange = paymentsTable.Cell(y, 1).Range;
                    cellRange.Text = row[1].ToString();
                    cellRange = paymentsTable.Cell(y, 2).Range;
                    cellRange.Text = row[2].ToString();
                    cellRange = paymentsTable.Cell(y, 3).Range;
                    cellRange.Text = row[3].ToString();
                    cellRange = paymentsTable.Cell(y, 4).Range;
                    cellRange.Text = row[4].ToString();
                    cellRange = paymentsTable.Cell(y, 5).Range;
                    cellRange.Text = row[5].ToString();
                    cellRange = paymentsTable.Cell(y, 6).Range;
                    cellRange.Text = row[6].ToString();
                    cellRange = paymentsTable.Cell(y, 7).Range;
                    cellRange.Text = row[7].ToString();
                    cellRange = paymentsTable.Cell(y, 8).Range;
                    cellRange.Text = row[8].ToString();
                    itog += Convert.ToDouble(row[4].ToString().Replace(".", ","));
                    y++;
                    if (y == orders.Rows.Count + 2)
                    {
                        paymentsTable.Rows.Add();
                        paymentsTable.Rows[y].Range.Bold = 1;
                        cellRange = paymentsTable.Cell(y, 3).Range;
                        cellRange.Text = "Итого:";
                        cellRange = paymentsTable.Cell(y, 4).Range;
                        cellRange.Text = itog.ToString().Replace(",", ".");
                    }
                }
            }
            else
            {
                foreach (DataRow Row in allStaff.Rows)
                {
                    Word.Paragraph animalsPar = document.Paragraphs.Add();
                    Word.Range animalsRange = animalsPar.Range;
                    animalsRange.Font.Size = 14;
                    animalsRange.Text = "Сотрудник: " + Row[0].ToString();
                    animalsPar.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    animalsRange.Bold = 1;
                    animalsRange.InsertParagraphAfter();

                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;
                    Word.Table paymentsTable = document.Tables.Add(tableRange, 1, 7);
                    paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    tableParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    Word.Range cellRange;
                    cellRange = paymentsTable.Cell(1, 1).Range;
                    cellRange.Text = "Получатель";
                    cellRange = paymentsTable.Cell(1, 2).Range;
                    cellRange.Text = "Дата заказа";
                    cellRange = paymentsTable.Cell(1, 3).Range;
                    cellRange.Text = "Дата получения";
                    cellRange = paymentsTable.Cell(1, 4).Range;
                    cellRange.Text = "Стоимость заказа";
                    cellRange = paymentsTable.Cell(1, 5).Range;
                    cellRange.Text = "Код";
                    cellRange = paymentsTable.Cell(1, 6).Range;
                    cellRange.Text = "Пункт выдачи";
                    cellRange = paymentsTable.Cell(1, 7).Range;
                    cellRange.Text = "Статус";
                    paymentsTable.Rows[1].Range.Bold = 1;
                    paymentsTable.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    int y = 2;
                    for (int i = 0; i < orders.Rows.Count; i++)
                    {
                        DataRow rows = orders.Rows[i];
                        if (rows[6].ToString() == Row[0].ToString())
                        {
                            paymentsTable.Rows.Add();
                            paymentsTable.Rows[y].Range.Bold = 0;
                            cellRange = paymentsTable.Cell(y, 1).Range;
                            cellRange.Text = rows[1].ToString();
                            cellRange = paymentsTable.Cell(y, 2).Range;
                            cellRange.Text = rows[2].ToString();
                            cellRange = paymentsTable.Cell(y, 3).Range;
                            cellRange.Text = rows[3].ToString();
                            cellRange = paymentsTable.Cell(y, 4).Range;
                            cellRange.Text = rows[4].ToString();
                            cellRange = paymentsTable.Cell(y, 5).Range;
                            cellRange.Text = rows[6].ToString();
                            cellRange = paymentsTable.Cell(y, 6).Range;
                            cellRange.Text = rows[7].ToString();
                            cellRange = paymentsTable.Cell(y, 7).Range;
                            cellRange.Text = rows[8].ToString();
                            itog += Convert.ToDouble(rows[4].ToString().Replace(".", ","));
                            y++;
                            if (y == orders.Rows.Count + 2)
                            {
                                paymentsTable.Rows.Add();
                                paymentsTable.Rows[y].Range.Bold = 1;
                                cellRange = paymentsTable.Cell(y, 3).Range;
                                cellRange.Text = "Итого:";
                                cellRange = paymentsTable.Cell(y, 4).Range;
                                cellRange.Text = itog.ToString().Replace(",", ".");
                            }
                        }
                    }
                    if (allStaff.Rows.Count - 1 != allStaff.Rows.IndexOf(Row))
                    {
                        document.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                    }
                }
            }
            application.Visible = true;
            try
            {
                document.SaveAs(Directory.GetCurrentDirectory() + @"\reports\Заказы за период " + sDate + poDate + staff + ".docx");
                MessageBox.Show("Документ сохранен под названием 'Заказы за период " + sDate + poDate + staff,"Отчет готов",MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Возникли ошибки при сохранении, но вы можете сохранить документ в ручную", "Внимание", MessageBoxButtons.OK);
            }
            groupBox2.Visible = false;
            sDate = "";
            poDate = "";
        }

        private void dateTimePickerS_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerS.CustomFormat = "yyyy-MM-dd";
            sDate = dateTimePickerS.Text;
        }

        private void dateTimePickerPo_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerPo.CustomFormat = "yyyy-MM-dd";
            poDate = dateTimePickerPo.Text;
        }
    }
}
