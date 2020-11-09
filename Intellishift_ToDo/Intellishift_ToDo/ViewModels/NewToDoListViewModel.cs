using System;
using Intellishift_ToDo.Models;
using Xamarin.Forms;

namespace Intellishift_ToDo.ViewModels
{
    public class NewToDoListViewModel :  BaseViewModel
    {
        private string description;
        private bool enabled = true; //Default a new list to active

        public NewToDoListViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(description);
        }

        public bool Enabled
        {
            get => enabled;
            set => SetProperty(ref enabled, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            ToDoList newToDoList = new ToDoList()
            {
                Id = Guid.NewGuid().ToString(),
                Description = Description,
                Enabled = Enabled
            };

            await ToDoListDataStore.AddToDoListAsync(newToDoList);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

    }
}