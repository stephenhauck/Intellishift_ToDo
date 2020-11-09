using Intellishift_ToDo.Models;
using Intellishift_ToDo.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Intellishift_ToDo.ViewModels
{
    [QueryProperty(nameof(ToDoListId), nameof(ToDoListId))]
    public class ItemsViewModel : BaseViewModel
    {

        private string toDoListId;
        private ToDoItem _selectedToDoItem;
        public ObservableCollection<ToDoItem> Items { get; }
        public Command LoadToDoItemsCommand { get; }
        public Command AddToDoItemCommand { get; }
        public Command<ToDoItem> ItemTapped { get; }

        
        public string ToDoListId
        {
            get
            {
                return toDoListId;
            }
            set
            {
                toDoListId = Uri.UnescapeDataString(value);
            }
        }

        public ItemsViewModel()
        {
            Title = "To Do Items";
            Items = new ObservableCollection<ToDoItem>();
            LoadToDoItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ToDoListId));
            ItemTapped = new Command<ToDoItem>(OnItemSelected);

            AddToDoItemCommand = new Command(OnAddItem);
        }




        async Task ExecuteLoadItemsCommand(string id)
        { 
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await ToDoItemDataStore.GetToDoItemsAsync(ToDoListId);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedToDoItem = null;
        }

        public ToDoItem SelectedToDoItem
        {
            get => _selectedToDoItem;
            set
            {
                SetProperty(ref _selectedToDoItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(NewItemPage)}?{nameof(NewItemViewModel.ToDoListId)}={ToDoListId}");
        }

        async void OnItemSelected(ToDoItem toDoItem)
        {
            if (toDoItem == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={toDoItem.Id}");
        }
    }
}