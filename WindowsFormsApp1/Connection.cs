using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public class Connection
    {
        private static string connectionString ="server=serverbtssiojv.ddns.net;port=3306;Database=martin_ado;Uid=martin;password=martin";
        public static MySqlConnection MyConnection { get; } = new MySqlConnection(connectionString);
        
        
    }
}