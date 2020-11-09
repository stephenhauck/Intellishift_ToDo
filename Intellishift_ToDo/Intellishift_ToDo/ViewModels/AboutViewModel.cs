using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Intellishift_ToDo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
            ResetDatabaseCommand = new Command(OnResetDatabase);
        }

        public ICommand OpenWebCommand { get; }

        public ICommand ResetDatabaseCommand { get; }

        private async void OnResetDatabase(object obj)
        {
            await ToDoListDataStore.DeleteAllObjects();
            await ToDoItemDataStore.DeleteAllObjects();

        }
    }
}