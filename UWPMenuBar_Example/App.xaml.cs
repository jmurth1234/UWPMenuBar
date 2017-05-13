using System;
using System.Threading.Tasks;
using UWPMenuBar_Example.Services;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Data;

namespace UWPMenuBar_Example
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
            var settings = SettingsService.Instance;
            RequestedTheme = settings.AppTheme;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}
