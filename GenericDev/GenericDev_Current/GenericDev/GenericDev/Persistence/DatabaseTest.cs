using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDev.Persistence
{
    public class DatabaseTest
    {
        public void Test()
        {
            var factory = new ConnectionFactory();
            var connection = factory.GetConnection();
            System.Diagnostics.Debug.WriteLine($"SQLite connection: {connection}");
            System.Diagnostics.Debug.WriteLine("done");

            connection.CreateTableAsync<ConfigEntry>().ContinueWith((results) =>
            {
                System.Diagnostics.Debug.WriteLine("Table created!");
            });
        }
    }
}
