using System;
using CR.UWP.Class;
using SQLite;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO.IsolatedStorage;
using CR.Interface;
using System.Threading.Tasks;
using Windows.System;
using Windows.ApplicationModel;

[assembly: Dependency(typeof(SQLliteAsync_UWP))]
namespace CR.UWP.Class
{
    public class SQLliteAsync_UWP : ISQLiteAsync
    {
        public SQLliteAsync_UWP() { }
        SQLiteAsyncConnection ISQLiteAsync.GetConnectionAsync()
        {
            var sqliteFilename = "CR.db";

            if (!File.Exists(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "CR.db")))
            {
                Task<bool> task = Task.Run(() => CopyDatabase());
                bool result = task.Result;


            }

            var conn = new SQLite.SQLiteAsyncConnection(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "CR.db"));
            return conn;
        }


        public async Task<bool> CopyDatabase()
        {
            bool isDatabaseExisting = false;
            try
            {
                StorageFile storageFile = await ApplicationData.Current.LocalFolder.GetFileAsync("CR.db");
                isDatabaseExisting = true;
            }
            catch
            {
                isDatabaseExisting = false;
            }

            if (!isDatabaseExisting)
            {
                var path = Path.Combine(Package.Current.InstalledLocation.Path, "CR.db");
                StorageFile databaseFile = await StorageFile.GetFileFromPathAsync(path);
                await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
            }
            return isDatabaseExisting;
        }




    }
}
