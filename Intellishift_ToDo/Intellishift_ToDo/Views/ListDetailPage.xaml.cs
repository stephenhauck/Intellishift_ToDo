using Intellishift_ToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Intellishift_ToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListDetailPage : ContentPage
    {
        readonly ListDetailViewModel _viewModel;

        public ListDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ListDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}