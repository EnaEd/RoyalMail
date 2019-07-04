using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;
using SQLite;

namespace RoyalMail.Android.Services
{
    public class TaskService : ITaskRepository
    {
        private SQLiteConnection _connection;
        public TaskService()
        {
            _connection = SQLiteConnectionService.Database;
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
            return _connection.Table<Task>().ToList();
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