using System.Windows;
using System.Windows.Controls;

namespace TailBlazer.LogViewer.Controls
{

    public class RegexIcon : Control
    {
        static RegexIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RegexIcon), new FrameworkPropertyMetadata(typeof(RegexIcon)));
        }
    }
}
