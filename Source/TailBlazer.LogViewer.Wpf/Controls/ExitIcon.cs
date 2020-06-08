using System.Windows;
using System.Windows.Controls;

namespace TailBlazer.LogViewer.Controls
{

    public class ExitIcon : Control
    {
        static ExitIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExitIcon), new FrameworkPropertyMetadata(typeof(ExitIcon)));
        }
    }
}
