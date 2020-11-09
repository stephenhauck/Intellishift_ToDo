using Intellishift_ToDo.Services;
using Xamarin.Forms;


namespace Intellishift_ToDo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<LiteDBToDoListDatastore>();
            DependencyService.Register<LiteDBToDoItemDatastore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
