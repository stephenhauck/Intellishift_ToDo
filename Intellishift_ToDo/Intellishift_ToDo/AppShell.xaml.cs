using Intellishift_ToDo.Views;
using System;
using Xamarin.Forms;

namespace Intellishift_ToDo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListDetailPage), typeof(ListDetailPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewToDoListPage), typeof(NewToDoListPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
