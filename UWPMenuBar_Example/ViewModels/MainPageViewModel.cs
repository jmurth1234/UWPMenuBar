using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using UWPMenuBar_Example.Services;
using Windows.System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Template10.Controls;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Rymate.Controls.UWPMenuBar;
using Windows.Foundation.Metadata;

namespace UWPMenuBar_Example.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private SettingsService settings;

        public MainPageViewModel()
        {
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            _AccentColor = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent);
            ApplicationViewTitleBar titlebar = ApplicationView.GetForCurrentView().TitleBar;
            titlebar.BackgroundColor = _AccentColor;
            titlebar.ButtonBackgroundColor = _AccentColor;

            if (ApiInformation.IsApiContractPresent("Windows.Phone.PhoneContract", 1, 0))
            {
                var statusBar = StatusBar.GetForCurrentView();
                statusBar.BackgroundColor = _AccentColor;
                statusBar.ForegroundColor = Colors.White;
                statusBar.BackgroundOpacity = 1;
            }

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                _AccentColor = Colors.SkyBlue;
            }
            else
            {
                settings = SettingsService.Instance;
                BindingDemo = new ObservableCollection<string>
                {
                    "Item 0", "Item 1", "Item 2"
                };
            }
        }

        private Color _AccentColor;

        public SolidColorBrush AccentColor
        {
            get
            {
                return new SolidColorBrush(_AccentColor);
            }
        }

        public bool ToggleTheme
        {
            get => settings.AppTheme.Equals(ApplicationTheme.Dark); 
            set { settings.AppTheme = value ? ApplicationTheme.Dark : ApplicationTheme.Light; base.RaisePropertyChanged(); }
        }

        public bool InlineTitleBar
        {
            get
            {
                CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                return coreTitleBar.ExtendViewIntoTitleBar;
            }
            set
            {
                CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
                coreTitleBar.ExtendViewIntoTitleBar = value;
                ShowTitle = value ? Visibility.Visible : Visibility.Collapsed;
                base.RaisePropertyChanged();
            }
        }

        private Visibility _ShowTitle;
        public Visibility ShowTitle
        {
            get
            {
                return _ShowTitle;
            }
            set
            {
                Set(ref _ShowTitle, value);
            }
        }


        public bool InlineSplitView
        {
            get => DisplayMode.Equals(SplitViewDisplayMode.Inline); 
            set
            {
                DisplayMode = value ? SplitViewDisplayMode.Inline : SplitViewDisplayMode.Overlay; base.RaisePropertyChanged();
                PaneOpen = value;
            }
        }

        private SplitViewDisplayMode _DisplayMode;

        public SplitViewDisplayMode DisplayMode
        {
            get => _DisplayMode; 
            set => Set(ref _DisplayMode, value); 
        }

        private bool _PaneOpen;

        public bool PaneOpen
        {
            get => _PaneOpen; 
            set
            {
                Set(ref _PaneOpen, value);
                base.RaisePropertyChanged();
            }
        }

        private ObservableCollection<String> _BindingDemo;

        public ObservableCollection<String> BindingDemo
        {
            get { return _BindingDemo; }
            set { Set(ref _BindingDemo, value); }
        }

        public void OpenPane() => PaneOpen = !PaneOpen;

        public void AddItem() => BindingDemo.Add("Item " + BindingDemo.Count);

        public void EnableScrolling(object sender, object e) => (sender as ScrollViewer).VerticalScrollMode = ScrollMode.Enabled;
    }

}
