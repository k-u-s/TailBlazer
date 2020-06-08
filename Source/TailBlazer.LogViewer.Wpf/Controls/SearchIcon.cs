using System.Windows;
using System.Windows.Controls;

namespace TailBlazer.LogViewer.Controls
{

    public class SearchIcon : Control
    {
        static SearchIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchIcon), new FrameworkPropertyMetadata(typeof(SearchIcon)));
        }
    }
}
