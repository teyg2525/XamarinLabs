using Prism;
using Prism.Ioc;
using labs.ViewModels;
using labs.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using labs.Database;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace labs
{
    public partial class App : PrismApplication
    {
        public const string DATABASE_NAME = "Tasks.db";
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(RootTabbedPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ITaskModelRepository>(Container.Resolve<TaskModelRepository>());

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RootTabbedPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ResultPage, ResultPageViewModel>();
            containerRegistry.RegisterForNavigation<Lab2ListPage, Lab2ListPageViewModel>();
            containerRegistry.RegisterForNavigation<AddTaskPage, AddTaskPageViewModel>();
            containerRegistry.RegisterForNavigation<TaskInfoPage, TaskInfoPageViewModel>();
        }
    }
}
