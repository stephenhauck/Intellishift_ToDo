using Intellishift_ToDo.Models;
using System;
using Xamarin.Forms;

namespace Intellishift_ToDo.ViewModels
{
    [QueryProperty(nameof(ToDoListId), nameof(ToDoListId))]
    public class NewItemViewModel : BaseViewModel
    {
        private string text;
        private string toDoListId;
        private bool completed;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text);
        }


        public string ToDoListId
        {
            get => toDoListId;
            set => SetProperty(ref toDoListId, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public bool Completed
        {
            get => completed;
            set => SetProperty(ref completed, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync($"..?ToDoListId={ToDoListId}");
        }

        private async void OnSave()
        {
            ToDoItem newToDoItem = new ToDoItem()
            {
                Id = Guid.NewGuid().ToString(),
                ToDoListId = ToDoListId,
                Text = Text, 
                Completed = Completed
            };

            await ToDoItemDataStore.AddToDoItemAsync(newToDoItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync($"..?ToDoListId={ToDoListId}");

        }
    }
}
