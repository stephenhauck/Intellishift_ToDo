using Intellishift_ToDo.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Intellishift_ToDo.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string toDoListId;
        private string text;
        private bool completed;

        public string Id { get; set; }

        public Command DeleteToDoItemCommand { get; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public string ToDoListId
        {
            get => toDoListId;
            set => SetProperty(ref toDoListId, value);
        }

        public bool Completed
        {
            get => completed;
            set => SetProperty(ref completed, value);
        }


        public ItemDetailViewModel()
        {
            Title = "Item Details";
            DeleteToDoItemCommand = new Command(OnDeleteItem);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text);
        }

        private async void OnDeleteItem(object obj)
        {

            await ToDoItemDataStore.DeleteToDoItemAsync(itemId);
            await Shell.Current.GoToAsync($"..?ToDoListId={ToDoListId}");
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await ToDoItemDataStore.GetToDoItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                ToDoListId = item.ToDoListId;
                Completed = item.Completed;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load ToDoItem");
            }
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
                Id = Id,
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
