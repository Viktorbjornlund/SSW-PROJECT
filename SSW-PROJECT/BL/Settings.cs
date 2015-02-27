using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Settings
    {
        private static string _connectionString;
        public static string ConnectionString
        {
            set { _connectionString = @"Data Source = TESTSERVER/SQLEXPRESS; Initial Catalog = DBbibliotek; Integrated Security = True"; }
            get { return _connectionString; }
        }
    }
}
