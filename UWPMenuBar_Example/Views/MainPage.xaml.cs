using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPMenuBar_Example.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            Window.Current.SetTitleBar(MenuBar.DragArea);
        }

        private void ScrollViewer_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            (sender as ScrollViewer).VerticalScrollMode = ScrollMode.Disabled;
        }

    }
}