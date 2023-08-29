using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace ApiClientes.Data
{
    public class SqlConfiguration
    {
        public SqlConfiguration(string connetionString) 
        {
            ConnectionString = connetionString;
        }
        public string ConnectionString {  get; set; }
    }
}
