using Intellishift_ToDo.Models;
using Intellishift_ToDo.ViewModels;
using Xamarin.Forms;

namespace Intellishift_ToDo.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ToDoItem ToDoItem { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}