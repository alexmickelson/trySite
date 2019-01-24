using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace try2.Services
{
    public class Connection : IDisposable
    {
        public NpgsqlConnection db;

        public Connection() 
        {
            db = new NpgsqlConnection("Server=postgres;Port=5432;Database=postgres;User Id=postgres;password=password");
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public NpgsqlConnection getDb()
        {
            return db;
        }
        
    }
}
