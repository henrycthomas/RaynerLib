using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace Rayner.Data
{
    public class Get
    {
        
        public static DataTable Table(string sql, Settings.DatabaseType databaseType = Settings.DatabaseType.MsSQL)
        {
            switch (databaseType)
            {
                case Settings.DatabaseType.MsSQL:
                    return MsSQL.Get.Table(sql);
                case Settings.DatabaseType.MySQL:
                    return MySQL.Get.Table(sql);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static DataTable StoredProcedure(string procedure, IEnumerable<Parameter> parameters, Settings.DatabaseType databaseType = Settings.DatabaseType.MsSQL)
        {
            switch (databaseType)
            {
                case Settings.DatabaseType.MsSQL:
                    return MsSQL.Get.StoredProcedure(procedure, parameters);
                case Settings.DatabaseType.MySQL:
                    return MySQL.Get.StoredProcedure(procedure, parameters);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
