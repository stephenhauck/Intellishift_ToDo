using Intellishift_ToDo.Models;
using Intellishift_ToDo.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Intellishift_ToDo.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {
        private ToDoList _selectedToDoList;
        public ObservableCollection<ToDoList> ToDoLists{ get; }
        public Command LoadToDoListCommand { get; }
        public Command AddToDoListCommand { get; }
        public Command DeleteToDoListCommand { get; }
        public Command<ToDoList> ItemTapped { get; }
       

        public ToDoListViewModel()
        {


            Title = "To Do Lists";
            ToDoLists = new ObservableCollection<ToDoList>();
            LoadToDoListCommand = new Command(async () => await ExecuteLoadToDoListCommand());

            
            ItemTapped = new Command<ToDoList>(OnItemSelected);

            AddToDoListCommand = new Command(OnAddList);
            DeleteToDoListCommand = new Command(OnDeleteList);
            
        }

        async Task ExecuteLoadToDoListCommand()
        {
            IsBusy = true;

            try
            {
                ToDoLists.Clear();
                var toDoList =  await ToDoListDataStore.GetToDoListAsync();
                foreach (var item in toDoList)
                {
                    ToDoLists.Add(item);
                }

                if (ToDoLists.Count < 1)
                {
                    await Application.Current.MainPage.DisplayAlert("No lists", "You have no to do lists, craete one with the Add button", "OK");
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
            SelectedToDoList = null;
        }

        public ToDoList SelectedToDoList
        {
            get => _selectedToDoList;
            set
            {
                SetProperty(ref _selectedToDoList, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddList(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewToDoListPage));
        }

        private async void OnDeleteList(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewToDoListPage));
        }

        async void OnItemSelected(ToDoList toDoList)
        {
            if (toDoList == null)
                return;

            // This will push the ListDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ListDetailPage)}?{nameof(ListDetailViewModel.ListId)}={toDoList.Id}");
            string tmp = toDoList.Id;
            await Shell.Current.GoToAsync($"{nameof(ItemsPage)}?{nameof(ItemsViewModel.ToDoListId)}={toDoList.Id}");
            // await Shell.Current.GoToAsync($”{nameof(Page2)}?Count={Count}”); 
        }
    }
}