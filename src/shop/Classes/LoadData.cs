using System.Data;
using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
namespace shop.Classes
{
    static class LoadData
    {
        public static DataTable Table(string stringQuery)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(Connection.GetConStr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(stringQuery, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при запросе данных, попробуте позже", "Ошибка", MessageBoxButtons.OK);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public static void Backup()
        {
            MySqlConnection con = new MySqlConnection(Connection.GetConStr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup back = new MySqlBackup(cmd);
                cmd.Connection = con;
                back.ExportToFile(Directory.GetCurrentDirectory() + "\\scripts\\myshop " + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".sql");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить резервное копирование\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        public static void Restore(string fileName)
        {
            MySqlConnection con = new MySqlConnection(Connection.GetConStr);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                MySqlBackup back = new MySqlBackup(cmd);
                cmd.Connection = con;
                back.ImportFromFile(Directory.GetCurrentDirectory() + "\\scripts\\" + fileName);
                MessageBox.Show("База данных была успешно восстановлена", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выполнить восстановление БД\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
