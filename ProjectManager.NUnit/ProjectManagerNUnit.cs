using System;

using ProjectManager.BussinessLayer;
using ProjectManagerServiceWebApi;
using ProjectManager.Entities;
using System.Collections.Generic;
using Moq;
using ProjectManager.DataLayer;
using System.Linq;
using NUnit.Framework;

namespace ProjectManager.NUnit
{
    [TestFixture]
    public class ProjectManagerNUnit
    {
        /// <summary>
        /// Testcases for TASKS
        /// </summary>
        /// 

        private TBusinessLayer task = new TBusinessLayer();

        [TestCase]
        public void GetTasks()
        {
            List<TaskTable> tasks = task.GetAllTasks().Where(i => i.TaskId.Equals(1745)).ToList();
        }

        [TestCase]
        public void SaveTasks()
        {
            var tasks = new TaskTable { 
                ProjectName = "TEST", ProjectId = 11454, TaskName = "TEST",
                Priority = 10,  ParentTask = "TEST",  IsParent = true,
                StartDate = Convert.ToDateTime("2019-11-19"), EndDate = Convert.ToDateTime("2019-11-19"),
                UserId = 1, UserName = "TEST",  Deleted = false, Status = "Completed"};

            bool added = task.Add(tasks);
            Assert.AreEqual(true, added);
        }

        [TestCase]
        public void UpdateTask()
        {
            var tasks = new TaskTable
            {
                TaskId = 11454,
                ProjectName = "TEST",
                ProjectId = 11454,
                TaskName = "TEST",
                Priority = 10,
                ParentTask = "TEST",
                IsParent = true,
                StartDate = Convert.ToDateTime("2019-11-19"),
                EndDate = Convert.ToDateTime("2019-11-19"),
                UserId = 1,
                UserName = "TEST",
                Deleted = false,
                Status = "Completed"
            };

            bool updated = task.Update(tasks.TaskId, tasks);
            Assert.AreEqual(true, updated);
        }

        [TestCase]
        public void DeleteTask()
        {
            var tasks = new TaskTable { ParentTask = "", TaskName = "Test", StartDate = Convert.ToDateTime("2019-11-19"), EndDate = Convert.ToDateTime("2019-11-19"), Priority = 20, Deleted = false };
            task.Add(tasks);

            List<TaskTable> toBeDeleteTask = task.GetAllTasks().Where(i => i.TaskName.Equals("Test") && i.Deleted.Equals(false)).ToList();

            bool deleted = task.Delete(toBeDeleteTask[0].TaskId);
            Assert.AreEqual(true, deleted);
        }

        /// <summary>
        /// Testcases for PROJECTS
        /// </summary>
        private PBusinessLayer project = new PBusinessLayer();

        [TestCase]
        public void GetProjects()
        {
            List<ProjectTable> projects = project.GetAllProjects().Where(i => i.ProjectId.Equals(5454)).ToList();
        }

        [TestCase]
        public void SaveProjects()
        {
            var projects = new ProjectTable
            {
                ProjectName = "TEST",
                Priority = 10,
                StartDate = Convert.ToDateTime("2019-11-19"),
                EndDate = Convert.ToDateTime("2019-11-19"),
                UserId = 1,
                ManagerName = "User 2",
                Deleted = false
            };

            bool added = project.Add(projects);
            Assert.AreEqual(true, added);
        }

        [TestCase]
        public void UpdateProject()
        {
            var projects = new ProjectTable
            {ProjectId = 1,
                ProjectName = "TEST",
                Priority = 10,
               StartDate = Convert.ToDateTime("2019-11-19"),
             EndDate = Convert.ToDateTime("2019-11-19"),
                UserId = 1,
                ManagerName = "User 2",
                Deleted = false
            };

            bool updated = project.Update(projects.ProjectId, projects);
            Assert.AreEqual(true, updated);
        }

        /// <summary>
        /// Testcases for USERS
        /// </summary>
        private UBusinessLayer user = new UBusinessLayer();

        [TestCase]
        public void GetUsers()
        {
            List<UserTable> users = user.GetAllUsers().Where(i => i.UserId.Equals(1002)).ToList();
        }

        [TestCase]
        public void SaveUsers()
        {
            var users = new UserTable
            {
FirstName = "TEST",
LastName = "TEST",
EmployeeId = 3,
Deleted = false
            };

            bool added = user.Add(users);
            Assert.AreEqual(true, added);
        }

        [TestCase]
        public void UpdateUser()
        {
            var users = new UserTable
            {
                UserId = 1472,
                FirstName = "TEST",
                LastName = "TEST",
                EmployeeId = 3,
                Deleted = false
            };

            bool updated = user.Update(users.UserId, users);
            Assert.AreEqual(true, updated);
        }
    }
}
