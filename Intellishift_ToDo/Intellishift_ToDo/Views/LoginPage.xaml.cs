using Intellishift_ToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Intellishift_ToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}