using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Rayner.Data.MySQL
{
    public class Set
    {
        public static void Execute(string sql)
        {
            var cmd = new MySqlCommand(sql, Connection.GetConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static int StoredProcedure(string procedure, IEnumerable<Parameter> parameters )
        {

            var cmd = new MySqlCommand(procedure, Connection.GetConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parameters.Select(x=>x.MYSQLParameter).ToArray());
            cmd.Connection.Open();
            var i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
