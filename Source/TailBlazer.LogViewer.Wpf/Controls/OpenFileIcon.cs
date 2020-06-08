using System.Windows;
using System.Windows.Controls;

namespace TailBlazer.LogViewer.Controls
{
    public class OpenFileIcon : Control
    {
        static OpenFileIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(OpenFileIcon), new FrameworkPropertyMetadata(typeof(OpenFileIcon)));
        }
    }
}
