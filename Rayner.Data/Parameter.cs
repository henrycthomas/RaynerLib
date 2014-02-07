using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Rayner.Data
{
    public class Parameter
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; }

        public MySqlDbType MysqlType
        {
            get
            {
                return MySQL.Build.SqlTypeToMySqlType(Type);
            }
        }

        public object Value { get; set; }
        public int Size { get; set; }

        public SqlParameter SQLParameter
        {
            get
            {
                var p = Size == -1 ? new SqlParameter(Name, Type) : new SqlParameter(Name, Type, Size);
                p.Value = Value;
                return p;
            }
        }

        public MySqlParameter MYSQLParameter
        {
            get
            {
                var p = Size == -1 ? new MySqlParameter(Name, MySQL.Build.SqlTypeToMySqlType(Type)) : new MySqlParameter(Name, MySQL.Build.SqlTypeToMySqlType(Type), Size);
                p.Value = Value;
                return p;
            }
        }

        private void Reset()
        {
            Name = string.Empty;
            Type = SqlDbType.VarChar;
            Value = null;
            Size = -1;
        }

        public Parameter(string name, SqlDbType type, object value = null)
        {
            Reset();
            Name = name;
            Type = type;
            if (value != null)
                Value = value;
        }
        public Parameter(string name, SqlDbType type, int size, object value = null)
        {
            Reset();
            Name = name;
            Type = type;
            Size = size;
            if (value != null)
                Value = value;
        }
    }
}
