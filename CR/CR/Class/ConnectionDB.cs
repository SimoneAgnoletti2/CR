using CR.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CR.Class
{
    public sealed class ConnectDB
    {
        ConnectDB()
        {
        }

        public static SQLiteConnection GetConnection
        {
            get
            {
                return NestedConnection.getConnection;
            }
        }

        public static SQLiteAsyncConnection GetConnectionAsync
        {
            get
            {
                return NestedConnectionAsync.getConnectionAsync;
            }
        }

        private class NestedConnection
        {
            static NestedConnection()
            {

            }
            internal static readonly SQLiteConnection getConnection = DependencyService.Get<ISQLite>().GetConnection();
        }

        private class NestedConnectionAsync
        {
            static NestedConnectionAsync()
            {

            }
            internal static readonly SQLiteAsyncConnection getConnectionAsync = DependencyService.Get<ISQLiteAsync>().GetConnectionAsync();
        }
    }
}
