using System;
using Microsoft.Maui.Controls;

namespace KaracanTestCase;

public partial class TaskEntry : ContentPage
{
	private readonly TaskService taskService;

	public TaskEntry(TaskService taskService)
	{
		InitializeComponent();
		this.taskService = taskService;
	}
	private async void SaveClicked(object sender, EventArgs e)
	{
		var taskName = TaskNameEntry.Text;
		if (string.IsNullOrWhiteSpace(taskName))
		{
			await DisplayAlert("Hata", "Görev adý boþ ya da NULL", "Tamam");
		}
        else
        {
			var task = new TaskName { Name = taskName };
			taskService.AddTask(task);
			await Navigation.PopAsync();
            await DisplayAlert("Basarili", "Görev basariyla eklendi", "Tamam");
        }
	}
}