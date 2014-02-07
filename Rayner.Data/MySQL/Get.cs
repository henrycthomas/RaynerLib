using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Rayner.Data.MySQL
{
    public class Get
    {
        public static DataTable Table(string sql)
        {
            var adp = new MySqlDataAdapter(sql, Connection.GetConnection());
            var ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable StoredProcedure(string procedure, IEnumerable<Parameter> parameters )
        {
            var cmd = new MySqlCommand(procedure, Connection.GetConnection())
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(parameters.Select(x=>x.MYSQLParameter).ToArray());
            cmd.Connection.Open();
            var dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            var dt = new DataTable();
            dt.Load(dr);
            return dt;
        }
    }
}
