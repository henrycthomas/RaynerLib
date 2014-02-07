using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Rayner.Data.MsSQL
{
    public class Build
    {
        public static void Table(string name, IEnumerable<Parameter> columns)
        {
            var columStrings = columns.Select(ParameterToTableColumn);
            var q = string.Format("CREATE TABLE {0} ({1})", name, columStrings.Aggregate((x, y) => x + "," + y));
            Set.Execute(q);
        }

        public static string ParameterToTableColumn(Parameter param)
        {
            return string.Format("{0} {1}{2}", param.Name, param.Type, param.Size == 0 ? "" : "("+param.Size+")");
        }

        public static SqlParameter Parameter(string name, SqlDbType type, int size = -1)
        {

            return size == -1 ? new SqlParameter(name, type) : new SqlParameter(name, type, size);
        }
    }
}
