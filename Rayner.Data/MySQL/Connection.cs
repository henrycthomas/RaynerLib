using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rayner.Data.MySQL
{
    public class Connection
    {
        public static MySql.Data.MySqlClient.MySqlConnection GetConnection()
        {
            return new MySql.Data.MySqlClient.MySqlConnection(ConnectionString());
        }

        public static string ConnectionString()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Settings.Host, Settings.Database,
                Settings.Username, Settings.Password);
        }
    }
}
