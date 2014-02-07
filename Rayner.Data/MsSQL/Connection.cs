using System.Data.SqlClient;

namespace Rayner.Data.MsSQL
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString());
        }

        public static string ConnectionString()
        {
            return string.Format("Server={0};Database={1};User Id={2};Password={3}", Settings.Host, Settings.Database,
                Settings.Username, Settings.Password);
        }
    }
}
