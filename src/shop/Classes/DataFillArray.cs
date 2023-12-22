using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace shop.Classes
{
    static class DataFillArray
    {
        static public string[] Read(string stringQuery, int numberPosition)
        {
            string[] read = new string[0];
            MySqlConnection con = new MySqlConnection(Connection.GetConStr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(stringQuery, con);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Array.Resize(ref read, read.Length + 1);
                    read[read.Length - 1] = rdr.GetString(numberPosition);
                }
            }
            catch (Exception e)
            {
                return read;
            }
            finally
            {
                con.Close();
            }
            return read;
        }
    }
}
