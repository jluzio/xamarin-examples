using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using PCLStorage;
using System.IO;
using SQLite;
using SQLite.Net.Async;
using SQLite.Net;

namespace GenericDev.Persistence
{
    public class ConnectionFactory
    {
        public SQLiteAsyncConnection GetConnection()
        {
            return new SQLiteAsyncConnection(() => GetSyncConnection());
        }

        private SQLiteConnectionWithLock GetSyncConnection()
        {
            var rootFolder = FileSystem.Current.LocalStorage;
            var dbPath = Path.Combine(rootFolder.Path, "app.db");
            var sqliteConnectionString = new SQLiteConnectionString(dbPath, true);

            var platformFactory = DependencyService.Get<ISQLitePlatformFactory>();
            var platform = platformFactory.GetInstance();

            return new SQLiteConnectionWithLock(platform, sqliteConnectionString);
        }
    }
}
