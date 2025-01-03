using AplicatieMobila.ViewModels;

namespace AplicatieMobila
{
    public partial class App : Application
    {
        public static CartViewModel CartViewModel { get; private set; }

        public App()
        {
            InitializeComponent();
            CartViewModel = new CartViewModel();


            MainPage = new NavigationPage(new AppShell());
        }
    }
}
