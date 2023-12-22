using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace shop.Classes
{
    public static class Request
    {
        static public bool RequestData(string stringQuery)
        {
            bool b = true;
            MySqlConnection con = new MySqlConnection(Connection.GetConStr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(stringQuery, con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
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
