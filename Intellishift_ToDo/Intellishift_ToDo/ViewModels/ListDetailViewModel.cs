using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Intellishift_ToDo.ViewModels
{
    [QueryProperty(nameof(ListId), nameof(ListId))]
    public class ListDetailViewModel : BaseViewModel
    {

        private string listId;
        private string description;
        private bool enabled;

        public string Id { get; set; }

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

        public string ListId
        {
            get
            {
                return listId;
            }
            set
            {
                listId = value;
                LoadToDoListDetails(value);
            }
        }

        public ListDetailViewModel()
        {
            Title = "List details";

        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public async void LoadToDoListDetails(string id)
        {
            try
            {
                var item = await ToDoListDataStore.GetToDoListAsync(id);
                Id = item.Id;
                Description = item.Description;
                Enabled = item.Enabled;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load ToDoListDetails");
            }
        }
    }
}