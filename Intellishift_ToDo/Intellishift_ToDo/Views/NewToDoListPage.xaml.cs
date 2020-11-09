using Intellishift_ToDo.Models;
using Intellishift_ToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Intellishift_ToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewToDoListPage : ContentPage
    {

        public ToDoList ToDoList { get; set; }
        public NewToDoListPage()
        {
            InitializeComponent();
            BindingContext = new NewToDoListViewModel();
        }
    }
}