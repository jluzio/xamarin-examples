using GenericDev.Droid.Persistence;
using GenericDev.Persistence;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLitePlatformFactory))]
namespace GenericDev.Droid.Persistence
{
    public class SQLitePlatformFactory : ISQLitePlatformFactory
    {
        public ISQLitePlatform GetInstance()
        {
            return new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        }
    }
}
