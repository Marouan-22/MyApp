using MyApp.ViewModels;
using MyApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MyApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            await NavigationService.NavigateAsync("NavigationPage/MainTabbedPage?createTab=TodoPage&createTab=WorkoutPage&createTab=HomePage&createTab=CalenderPage&createTab=TimerPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MainTabbedPage, MainTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<WorkoutPage, WorkoutPageViewModel>();
            containerRegistry.RegisterForNavigation<TodoPage, TodoPageViewModel>();
            containerRegistry.RegisterForNavigation<CalenderPage, CalenderPageViewModel>();
            containerRegistry.RegisterForNavigation<TimerPage, TimerPageViewModel>();
        }
    }
}
