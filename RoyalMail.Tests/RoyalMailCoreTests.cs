using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoyalMail.Android.Repository;
using RoyalMail.Android.Services;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;
using SQLite;

namespace RoyalMail.Tests
{
    [TestClass]
    public class RoyalMailCoreTests
    {
        private SQLiteConnection _connection;
        private ITaskRepository _repository;
        private Task _testTask;
        public RoyalMailCoreTests()
        {
            string taskdetail = "new unit test task";
            _testTask = new Task
            {
                IsComlete = false,
                TaskDetail = $"{taskdetail}4...",
                TaskName = $"{taskdetail.Substring(0, 10)}..."
            };

            _connection = new SQLiteConnection(":memory:");
            _repository = new TaskRepository(new SQLiteConnectionService(_connection));
            _connection.Insert(_testTask);
        }
        [TestMethod]
        public void CreateTaskTest()
        {
            //Arrange
            _testTask = new Task
            {
                IsComlete = false,
                TaskDetail = "new test task",
                TaskName = "new test task"
            };
            //Act
            _repository.Save(_testTask);
            //Assert
            Assert.IsTrue(_testTask.Id > 0);
        }
        [TestMethod]
        public void UpdateTaskTest()
        {
            //Arrange
            string newTaskName = "changed";
            //Act
            _testTask = _repository.GetById(_testTask.Id);
            Task changedTask = new Task
            {
                Id = _testTask.Id,
                TaskName = newTaskName,
                TaskDetail = _testTask.TaskDetail,
                IsComlete = _testTask.IsComlete
            };
            _repository.Save(changedTask);
            string result = _repository.GetById(_testTask.Id).TaskName;
            //Assert
            Assert.AreEqual(newTaskName, result);
        }
        [TestMethod]
        public void GetByIdWithId_1Test()
        {
            //Act
            var result = _repository.GetById(_testTask.Id);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_testTask.TaskName, result.TaskName);
        }
        [TestMethod]
        public void GetAnyTest()
        {
            //Act
            var result = _repository.GetAll().ToList();
            //Assert
            Assert.IsTrue(result.Any());
        }
        [TestMethod]
        public void DeleteTaskWithId_1Test()
        {
            //Act
            _repository.Delete(_testTask.Id);
            //Assert
            Assert.IsTrue(_repository.GetById(_testTask.Id) is null);
        }
    }
}
