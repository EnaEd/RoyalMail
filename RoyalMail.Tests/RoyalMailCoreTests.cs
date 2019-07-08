using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmCross;
using RoyalMail.Android.Services;
using RoyalMail.Core.Interfaces;
using RoyalMail.Core.Models;

namespace RoyalMail.Tests
{
    [TestClass]
    public class RoyalMailCoreTests
    {
        [TestMethod]
        public void SaveTaskTest()
        {
            //Arrange
            string taskdetail = "new unit test task";
            Task testTask = new Task
            {
                IsComlete = false,
                TaskDetail = $"{taskdetail}4...",
                TaskName = $"{taskdetail.Substring(0, 10)}..."

            };
            var mock = new Mock<ITaskRepository>();
            mock.Setup(x => x.Save(It.IsAny<Task>())) 
            .Callback<Task>(x => { x.Id = 1; });
            //Act
            mock.Object.Save(testTask);
            //Assert
            Assert.IsTrue(testTask.Id > 0);
        }
        [TestMethod]
        public void GetByIdWithId_1Test()
        {
            //Arrange
            string taskdetail = "new unit test task";
            Task testTask = new Task
            {
                Id=1,
                IsComlete = false,
                TaskDetail = $"{taskdetail}4...",
                TaskName = $"{taskdetail.Substring(0, 10)}..."

            };
            var mock = new Mock<ITaskRepository>();
            mock.Setup(x => x.GetById(1))
            .Returns(testTask);
            //Act
            var result=mock.Object.GetById(1);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testTask.TaskName, result.TaskName);
        }
        [TestMethod]
        public void GetAllTest()
        {
            //Arrange
            string taskdetail = "new unit test task";
            Task testTask = new Task
            {
                Id = 1,
                IsComlete = false,
                TaskDetail = $"{taskdetail}4...",
                TaskName = $"{taskdetail.Substring(0, 10)}..."

            };
            var mock = new Mock<ITaskRepository>();
            mock.Setup(x => x.GetAll())
            .Returns(new List<Task>() { testTask });
            //Act
            var result = mock.Object.GetAll();
            //Assert
            Assert.IsTrue(result.Any());
        }
        [TestMethod]
        public void DeleteTaskWithId_1()
        {
            //Arrange
            string taskdetail = "new unit test task";
            Task testTask = new Task
            {
                Id=1,
                IsComlete = false,
                TaskDetail = $"{taskdetail}4...",
                TaskName = $"{taskdetail.Substring(0, 10)}..."

            };
            var mock = new Mock<ITaskRepository>();
            mock.Setup(x => x.Delete(1))
                .Callback(()=>testTask=null);
            //Act
            mock.Object.Delete(1);
            //Assert
            Assert.IsTrue(testTask is null);
        }
    }
}
