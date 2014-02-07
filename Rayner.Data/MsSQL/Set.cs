using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Rayner.Data.MsSQL
{
    public class Set
    {
        public static void Execute(string sql)
        {
            var cmd = new SqlCommand(sql, Connection.GetConnection());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static int StoredProcedure(string procedure, IEnumerable<Parameter> parameters )
        {
            var cmd = new SqlCommand(procedure, Connection.GetConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parameters.Select(x=>x.SQLParameter).ToArray());
            cmd.Connection.Open();
            var i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
