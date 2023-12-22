namespace shop.Classes
{
    static public class Connection
    {
        //static private string _conStr = "server=10.207.106.12;uid=user60;pwd=fv29;database=db60;charset=utf8";
        private static readonly string _conStr = "server=localhost;uid=root;pwd=12345;database=db60;charset=utf8";
        static public string GetConStr
        {
            get
            {
                return _conStr;
            }
        }
    }
}
