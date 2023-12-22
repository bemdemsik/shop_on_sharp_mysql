namespace shop.Classes
{
    static class UserInformation
    {
        static private string _role = "";
        static private string _fio = "";
        static private string _telephone = "";

        static public string GetRole
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
        static public string GetFIO
        {
            get
            {
                return _fio;
            }
            set
            {
                _fio = value;
            }
        }
        static public string GetTelephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                _telephone = value;
            }
        }
    }
}
