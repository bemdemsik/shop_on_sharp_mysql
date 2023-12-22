using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using shop.Classes;
namespace shop.Forms
{
    public partial class ShowStructureOrder : Form
    {
        string request = "";
        string oldSearch = "";
        string startDate = "";
        string finishDate = "";
        string oldOrderBy = "";
        int numberPage = 1;
        int oldNumberRowActive = 0;
        public ShowStructureOrder()
        {
            InitializeComponent();
        }
        public ShowStructureOrder(DataGridViewRow row, int numberRowActive, string search, string startDate1, string finishDate1, string orderby, int numberActivePage)
        {
            oldSearch = search;
            startDate = startDate1;
            finishDate = finishDate1;
            oldOrderBy = orderby;
            numberPage = numberActivePage;
            oldNumberRowActive = numberRowActive;
            request = "select id,(select productName from product where articule=idproduct) as 'Наименование',countProduct as 'Количество',costProduct as 'Стоимость' from ordersstructure where idorders="+row.Cells["id"].Value.ToString();
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowOrders q = new ShowOrders(oldNumberRowActive, oldSearch, startDate, finishDate, oldOrderBy, numberPage);
            q.ShowDialog();
        }
        private void ShowStructure()
        {
            dataGridView1.DataSource = LoadData.Table(request);
            try
            {
                dataGridView1.Columns["id"].Visible = false;
            }
            catch
            {
                return;
            }
        }
        private void ShowStructureOrder_Load(object sender, EventArgs e)
        {
            ShowStructure();
        }
    }
}
