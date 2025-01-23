using System;
using Microsoft.Maui.Controls;

namespace KaracanTestCase
{
    public partial class MainPage : ContentPage
    {
        private readonly TaskService taskService;
        public MainPage()
        {
            InitializeComponent();
            taskService = new TaskService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void AddTaskClicked(object sender, EventArgs e)
        {
            var taskEntry = new TaskEntry(taskService);
            await Navigation.PushAsync(taskEntry);
        }
        private async void ViewTasksClicked(object sender, EventArgs e)
        {
            var taskListPage = new TaskList(taskService);
            await Navigation.PushAsync(taskListPage);
        }
    }
}
