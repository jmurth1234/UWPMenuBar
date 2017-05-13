using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Rymate.Controls.UWPMenuBar
{
    /// <summary>
    /// This class reduces the padding of a MenuFlyoutItem.
    /// </summary>
    public sealed class MenuBarItem : MenuFlyoutItem
    {
        public MenuBarItem() : base()
        {
            Padding = new Thickness(8);
        }
    }

    /// <summary>
    /// This class reduces the padding of a ToggleMenuFlyoutItem.
    /// </summary>
    public sealed class MenuBarToggleItem : ToggleMenuFlyoutItem
    { 
        public MenuBarToggleItem() : base()
        {
            Padding = new Thickness(8);
        }
    }
}
