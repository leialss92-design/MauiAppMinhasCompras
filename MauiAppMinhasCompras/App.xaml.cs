namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        [Obsolete]
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}