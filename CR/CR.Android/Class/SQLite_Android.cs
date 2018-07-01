using CR.Interface;
using Xamarin.Forms;
using CR.Droid.Class;
using SQLite;
using System.IO;
using Android.Content.Res;
using System;

[assembly: Dependency(typeof(SQLite_Android))]
namespace CR.Droid.Class
{

    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        SQLiteConnection ISQLite.GetConnection()
        {
            var sqliteFilename = @"CR.db";

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                CopyDatabaseIfNotExists(path, sqliteFilename);
            }
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }

        private static void CopyDatabaseIfNotExists(string dbPath, string sqliteFilename)
        {
            try
            {
                using (var br = new BinaryReader(Forms.Context.Assets.Open("DB/" + sqliteFilename)))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                        bw.Close();
                    }
                    br.Close();
                }

                AssetManager assets = Forms.Context.Assets;

                System.Diagnostics.Debug.WriteLine("Database Copies Successfully.");
            }
            catch (Exception pException)
            {
                System.Diagnostics.Debug.WriteLine("Error in copied Database : " + pException.Message);
            }
        }
    }
}