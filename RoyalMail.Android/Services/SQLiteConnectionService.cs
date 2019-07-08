using System.IO;
using RoyalMail.Core.Models;
using SQLite;

namespace RoyalMail.Android.Services
{
    public class SQLiteConnectionService
    {
        public SQLiteConnectionService()
        {
            Database = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TaskDatabase.db"));
            Database.CreateTable<Task>();
        }
        public SQLiteConnectionService(SQLiteConnection connection)
        {
            Database = connection;
            Database.CreateTable<Task>();
        }
        public SQLiteConnection Database { get; set; }
    }
}