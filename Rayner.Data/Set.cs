using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Rayner.Data
{
    public class Set
    {
        public static void Execute(string sql, Settings.DatabaseType databaseType = Settings.DatabaseType.MsSQL)
        {
            switch (databaseType)
            {
                case Settings.DatabaseType.MySQL:
                    MySQL.Set.Execute(sql);
                    break;
                case Settings.DatabaseType.MsSQL:
                    MsSQL.Set.Execute(sql);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("databaseType");
            }
        }
        public static int StoredProcedure(string procedure, IEnumerable<Parameter> paramaters, Settings.DatabaseType databaseType = Settings.DatabaseType.MsSQL)
        {
            switch (databaseType)
            {
                case Settings.DatabaseType.MsSQL:
                    return MsSQL.Set.StoredProcedure(procedure, paramaters);
                case Settings.DatabaseType.MySQL:
                    return MySQL.Set.StoredProcedure(procedure, paramaters);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
