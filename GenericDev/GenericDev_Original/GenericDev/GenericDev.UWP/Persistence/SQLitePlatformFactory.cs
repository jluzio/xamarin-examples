using GenericDev.Persistence;
using GenericDev.UWP.Persistence;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLitePlatformFactory))]
namespace GenericDev.UWP.Persistence
{
    public class SQLitePlatformFactory : ISQLitePlatformFactory
    {
        public ISQLitePlatform GetInstance()
        {
            return new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
        }
    }
}
