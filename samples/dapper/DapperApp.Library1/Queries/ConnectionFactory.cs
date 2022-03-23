using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DapperApp.Library1.Queries
{
    public class ConnectionFactory
    {
        public SqlConnection CreateConnection() => new SqlConnection("Server=localhost;Database=Samples;Trusted_Connection=True;");

        public void RunCommand(Action<SqlConnection> action)
        {
            action(CreateConnection());
        }
    }
}
