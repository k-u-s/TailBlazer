using System.Windows;
using System.Windows.Controls;

namespace TailBlazer.LogViewer.Controls
{

    public class RemoveIcon : Control
    {
        static RemoveIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RemoveIcon), new FrameworkPropertyMetadata(typeof(RemoveIcon)));
        }
    }
}
