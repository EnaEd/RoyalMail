using System.IO;
using RoyalMail.Core.Models;
using SQLite;

namespace RoyalMail.Android.Services
{
    public static class SQLiteConnectionService
    {
        public static SQLiteConnection Database;
        static SQLiteConnectionService()
        {
            Database = new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TaskDatabase.db"));
            Database.CreateTable<Task>();
        }
    }
}