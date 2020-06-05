using System.Windows;
using System.Windows.Controls;

namespace TailBlazer.LogViewer.Controls
{

    public class SaveLayoutIcon : Control
    {
        static SaveLayoutIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SaveLayoutIcon), new FrameworkPropertyMetadata(typeof(SaveLayoutIcon)));
        }
    }
}
