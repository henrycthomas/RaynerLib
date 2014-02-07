using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Rayner.Data
{
    class Build
    {
        public static void Table(string name, IEnumerable<Parameter> parameters,
            Settings.DatabaseType dbType = Settings.DatabaseType.MsSQL)
        {
            switch (dbType)
            {
                case Settings.DatabaseType.MySQL:
                    MySQL.Build.Table(name, parameters);
                    break;
                case Settings.DatabaseType.MsSQL:
                    MsSQL.Build.Table(name, parameters);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("dbType");
            }
        }
    }
}
