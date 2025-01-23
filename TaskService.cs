using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaracanTestCase
{
    public class TaskService
    {
        private readonly ObservableCollection<TaskName> tasks = new ObservableCollection<TaskName>();
        public void AddTask(TaskName task)
        {
            tasks.Add(task);
        }
        public ObservableCollection<TaskName> GetTasks()
        {
            return tasks;
        }
        public void RemoveTask(TaskName task)
        {
            tasks.Remove(task);
        }
    }
}
