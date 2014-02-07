using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Speech.Recognition.SrgsGrammar;
using System.Text;
using System.Windows.Forms;
using Rayner.Data;
namespace Rayner.Tester
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(Data.MsSQL.Connection.ConnectionString());
            Console.WriteLine(Data.MySQL.Connection.ConnectionString());
            Data.MsSQL.Build.Table("TableA", new List<SqlParameter>
            {
                new SqlParameter("Param1", SqlDbType.Bit),
                new SqlParameter("Param2", SqlDbType.VarChar, 100),
                new SqlParameter("Param3", SqlDbType.Char, 10)
            });
            Console.ReadLine();
        }
    }
}
