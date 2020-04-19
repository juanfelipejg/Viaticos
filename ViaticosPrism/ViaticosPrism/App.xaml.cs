using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Viaticos.Prism.ViewModels;
using Viaticos.Prism.Views;
using Viaticos.Common.Services;
using Syncfusion.Licensing;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ViaticosPrism
{
    public partial class App
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            SyncfusionLicenseProvider.RegisterLicense("MjQyNzA5QDMxMzgyZTMxMmUzMG9DNUNQcWl1WFVJVTJsMEVXS01ZRHA0NTZaTkxORnIrSVhpcFFNWlNmekk9");
            InitializeComponent();

            await NavigationService.NavigateAsync("/ViaticosMasterDetailPage/NavigationPage/TripPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TripPage,TripPageViewModel>();
            containerRegistry.RegisterForNavigation<TripDetailsPage, TripDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<ViaticosMasterDetailPage, ViaticosMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
