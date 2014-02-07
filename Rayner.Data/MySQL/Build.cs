using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Rayner.Data.MySQL
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
            return string.Format("{0} {1}{2}", param.Name, param.MysqlType, param.Size == 0 ? "" : "(" + param.Size + ")");
        }

        public static MySqlDbType SqlTypeToMySqlType(SqlDbType sqlType)
        {
            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return MySqlDbType.Int32;
                case SqlDbType.Binary:
                    return MySqlDbType.Binary;
                case SqlDbType.Bit:
                    return MySqlDbType.Bit;
                case SqlDbType.Char:
                    return MySqlDbType.VarChar;
                case SqlDbType.DateTime:
                    return MySqlDbType.DateTime;
                case SqlDbType.Decimal:
                    return MySqlDbType.Decimal;
                case SqlDbType.Float:
                    return MySqlDbType.Float;
                case SqlDbType.Image:
                    throw new Exception("Image type is not supported in MySql");
                case SqlDbType.Int:
                    return MySqlDbType.Int32;
                case SqlDbType.Money:
                    throw new Exception("Money type is not supported in MySql");
                case SqlDbType.NChar:
                    return MySqlDbType.VarChar;
                case SqlDbType.NText:
                    return MySqlDbType.Text;
                case SqlDbType.NVarChar:
                    return MySqlDbType.VarChar;
                case SqlDbType.Real:
                    throw new Exception("Real type is not supported in MySql");
                case SqlDbType.UniqueIdentifier:
                    return MySqlDbType.Guid;
                case SqlDbType.SmallDateTime:
                    return MySqlDbType.DateTime;
                case SqlDbType.SmallInt:
                    return MySqlDbType.Int16;
                case SqlDbType.SmallMoney:
                    throw new Exception("SmallMoney type is not supported in MySql");
                case SqlDbType.Text:
                    return MySqlDbType.Text;
                case SqlDbType.Timestamp:
                    return MySqlDbType.Timestamp;
                case SqlDbType.TinyInt:
                    return MySqlDbType.Int16;
                case SqlDbType.VarBinary:
                    return MySqlDbType.VarBinary;
                case SqlDbType.VarChar:
                    return MySqlDbType.VarChar;
                case SqlDbType.Variant:
                    throw new Exception("Varient type is not supported in MySql");
                case SqlDbType.Xml:
                    return MySqlDbType.Text;
                case SqlDbType.Udt:
                    throw new Exception("UDT type is not supported in MySql");
                case SqlDbType.Structured:
                    throw new Exception("Structured type is not supported in MySql");
                case SqlDbType.Date:
                    return MySqlDbType.Date;
                case SqlDbType.Time:
                    return MySqlDbType.Time;
                case SqlDbType.DateTime2:
                    return MySqlDbType.DateTime;
                case SqlDbType.DateTimeOffset:
                    throw new Exception("DateTimeOffset type is not supported in MySql");
                default:
                    throw new ArgumentOutOfRangeException("sqlType");
            }
        }
        public static MySqlParameter Parameter(string name, MySqlDbType type, int size = -1)
        {

            return size == -1 ? new MySqlParameter(name, type) : new MySqlParameter(name, type, size);
        }
    }
}
