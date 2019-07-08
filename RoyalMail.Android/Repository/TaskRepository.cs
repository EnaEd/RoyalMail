using System.Collections.Generic;
using RoyalMail.Android.Services;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;
using SQLite;

namespace RoyalMail.Android.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private SQLiteConnection _connection;
        public TaskRepository(SQLiteConnectionService database)
        {
            _connection = database.Database;
        }
        public void Delete(int id)
        {
            Task task = _connection.Find<Task>(id);
            if (task != null)
            {
                _connection.Delete(task);
            }
        }

        public IEnumerable<Task> GetAll()
        {
            var t= _connection.Table<Task>().ToList();
            return t;
        }

        public Task GetById(int id)
        {
            return _connection.Find<Task>(id);
        }

        public void Save(Task item)
        {
            if (item.Id != default(int))
            {
                _connection.Update(item);
                return;
            }
            _connection.Insert(item);
        }
    }
}