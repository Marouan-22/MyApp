using MyApp.Models;
using MyApp.Repository;
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

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
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
            containerRegistry.RegisterForNavigation<TimerPage, TimerPageViewModel>();
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>();
            containerRegistry.RegisterForNavigation<BMICalculator, BMICalculatorViewModel>();
            containerRegistry.RegisterForNavigation<NewTodoPage, NewTodoPageViewModel>();
            containerRegistry.RegisterForNavigation<TodoDetailPage, TodoDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<EditTodoPage, EditTodoPageViewModel>();

            containerRegistry.RegisterSingleton<ITodoRepository<Todo>, TodoRepository>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<WorkoutDetailPage, WorkoutDetailPageViewModel>();
            containerRegistry.RegisterSingleton<IWorkoutRepository<Workout>, workoutRepository>();
        }
    }
}
