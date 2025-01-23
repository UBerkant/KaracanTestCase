using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace KaracanTestCase
{
    public class TaskService
    {
        private readonly string databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.db");
        private readonly string collectionName = "tasks";
        public void AddTask(TaskName task)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var tasks = db.GetCollection<TaskName>(collectionName);
                tasks.Insert(task);
            }
        }
        public ObservableCollection<TaskName> GetTasks()
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var tasks = db.GetCollection<TaskName>(collectionName);
                return new ObservableCollection<TaskName>(tasks.FindAll().ToList());
            }
        }
        public void RemoveTask(TaskName task)
        {
            using (var db = new LiteDatabase(databasePath))
            {
                var tasks = db.GetCollection<TaskName>(collectionName);
                tasks.Delete(task.Id);
            }
        }
    }
}
