using System;
using Microsoft.Maui.Controls;

namespace KaracanTestCase
{
    public partial class TaskList : ContentPage
    {
        private readonly TaskService taskService;

        public TaskList(TaskService taskService)
        {
            InitializeComponent();
            this.taskService = taskService;
            TaskListView.ItemsSource = taskService.GetTasks();
        }
        private void LoadTasks()
        {
            TaskListView.ItemsSource = taskService.GetTasks();
        }

        private async void OnTaskSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedTask = e.SelectedItem as TaskName;

            var answer = await DisplayAlert("Silmek Ýstediðinizden Emin Misiniz?",
                                             $"Görev: {selectedTask.Name}",
                                             "Evet", "Hayýr");

            if (answer)
            {
                taskService.RemoveTask(selectedTask);
            }
        }
    }
}
