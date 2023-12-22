using System;
using MySql.Data.MySqlClient;

namespace shop.Classes
{
    static class ReadOneStr
    {
        static public string[] Read(string stringQuery)
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
                    for (;;)
                    {
                        Array.Resize(ref read, read.Length + 1);
                        read[read.Length - 1] = rdr.GetString(read.Length - 1);
                    }
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
