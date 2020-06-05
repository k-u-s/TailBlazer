using System.Windows;
using System.Windows.Controls;

namespace TailBlazer.LogViewer.Controls
{

    public class FilterIcon : Control
    {
        static FilterIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilterIcon), new FrameworkPropertyMetadata(typeof(FilterIcon)));
        }
    }
}
