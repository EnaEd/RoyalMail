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
            _connection = new SQLiteConnection(":memory:");
            _repository = new TaskRepository(new SQLiteConnectionService(_connection));

            string taskdetail = "new unit test task";
            _testTask = new Task
            {
                IsComlete = false,
                TaskDetail = $"{taskdetail}4...",
                TaskName = $"{taskdetail.Substring(0, 10)}..."
            };
        }
        [TestMethod]
        public void CreateTaskTest()
        {
            //Arrange

            //Act
            _repository.Save(_testTask);
            //Assert
            Assert.IsTrue(_testTask.Id > 0);
        }
        [TestMethod]
        public void UpdateTaskTest()
        {
            //Arrange
            _repository.Save(_testTask);
            int id = 1;

            //Act
            _testTask.TaskName = "changed";
            _repository.Save(_testTask);
            //Assert
            Assert.IsTrue(_testTask.Id == id);
            Assert.AreEqual("changed", _testTask.TaskName);
        }
        [TestMethod]
        public void GetByIdWithId_1Test()
        {
            //Arrange
            _repository.Save(_testTask);

            //Act
            var result = _repository.GetById(1);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_testTask.TaskName, result.TaskName);
        }
        [TestMethod]
        public void GetAllTest()
        {
            //Arrange
            _repository.Save(_testTask);

            //Act
            var result = _repository.GetAll().ToList();
            //Assert
            Assert.IsTrue(result.Any());
        }
        [TestMethod]
        public void DeleteTaskWithId_1Test()
        {
            //Arrange
            _repository.Save(_testTask);
            //Act
            _repository.Delete(1);
            //Assert
            Assert.IsTrue(_repository.GetById(1) is null);
        }
    }
}
