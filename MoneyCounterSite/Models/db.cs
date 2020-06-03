using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MoneyCounterSite.Models
{
    public class db
    {
        string connectionstring = @"Server=tcp:new-sql-server.database.windows.net,1433;Initial Catalog=MonyCounter;Persist Security Info=False;User ID=adm;Password=hAp3KQDndFyP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public SqlConnection sc;
        public SqlCommand command;
        public SqlDataReader rd;
        public string sql;
        public db()
        {
            sc = new SqlConnection(connectionstring);
            sc.Open();
        }
    }
}