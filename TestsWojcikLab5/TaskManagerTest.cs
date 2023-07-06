using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WojcikLab5;

namespace TestsWojcikLab5
{
    public class TaskManagerTest
    {
        private TaskManager _taskManager;
        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }
        [Test]
        public void AddTask_ShouldIncreaseTaskCount()
        {
            // Arrange
            var task = new WojcikLab5.Task("Test task");
            // Act
            _taskManager.AddTask(task);
            // Assert
            Assert.AreEqual(1, _taskManager.GetTasks().Count);
        }

        [Test]
        public void RemoveTask_ExistingTask_ShouldDecreaseTaskCount()
        {
            // Arrange
            var task = new WojcikLab5.Task("Test task");
            _taskManager.AddTask(task);
            int initialTaskCount = _taskManager.GetTasks().Count;

            // Act
            _taskManager.RemoveTask(task.Id);

            // Assert
            Assert.AreEqual(initialTaskCount - 1, _taskManager.GetTasks().Count);
            Assert.IsFalse(_taskManager.GetTasks().Contains(task));
        }


        [Test]
        public void GetTasks_ShouldReturnAllTasks()
        {
            // Arrange
            var task1 = new WojcikLab5.Task("Test task 1");
            var task2 = new WojcikLab5.Task("Test task 2");
            _taskManager.AddTask(task1);
            _taskManager.AddTask(task2);

            // Act
            List<WojcikLab5.Task> tasks = _taskManager.GetTasks();

            // Assert
            Assert.Contains(task1, tasks);
            Assert.Contains(task2, tasks);
            Assert.AreEqual(2, tasks.Count);
        }


    }
}
