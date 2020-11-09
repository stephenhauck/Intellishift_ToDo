using Intellishift_ToDo.ViewModels;
using Xamarin.Forms;

namespace Intellishift_ToDo.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}