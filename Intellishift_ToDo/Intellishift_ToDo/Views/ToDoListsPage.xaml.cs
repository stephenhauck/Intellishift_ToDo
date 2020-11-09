using Intellishift_ToDo.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Intellishift_ToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoListsPage : ContentPage
    {
        readonly ToDoListViewModel _viewModel;

        public ToDoListsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ToDoListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}