using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Rayner.Data.MsSQL
{
    public class Get
    {
        public static DataTable Table(string sql)
        {
            var adp = new SqlDataAdapter(sql, Connection.GetConnection());
            var ds = new DataSet();
            adp.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable StoredProcedure(string procedure, IEnumerable<Parameter> parameters)
        {
            var com = new SqlCommand(procedure, Connection.GetConnection()) {CommandType = CommandType.StoredProcedure};
            com.Parameters.AddRange(parameters.Select(x=>x.SQLParameter).ToArray());
            var dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            var dt = new DataTable();
            dt.Load(dr);
            return dt;
        }
    }
}
