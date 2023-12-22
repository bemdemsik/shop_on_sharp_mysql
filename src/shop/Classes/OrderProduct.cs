using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using shop.Classes;
namespace shop.Classes
{
    static class OrderProduct
    {
        static public bool RequestData(string[] stringQuery)
        {
            bool b = true;
            MySqlConnection con = new MySqlConnection(Connection.GetConStr);
            con.Open();
            MySqlTransaction tran = con.BeginTransaction();
            try
            {
                foreach (string request in stringQuery)
                {
                    MySqlCommand cmd = new MySqlCommand(request, con, tran);
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                MessageBox.Show(e.Message);
                b = false;
            }
            finally
            {
                con.Close();
            }
            return b;
        }
    }
}
