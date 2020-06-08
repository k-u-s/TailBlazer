using System.IO;
using System.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TailBlazer.LogViewer.Infrastucture.Virtualisation;

namespace TailBlazer.LogViewer.Views.Tail
{
    public class TailView : UserControl
    {
        /// <summary>
        /// Indicates whether the Splitter resizes the Columns, Rows, or Both.
        /// </summary>
        public string FilePath
        {
            get => GetValue(FilePathProperty);
            set => SetValue(FilePathProperty, value);
        }

        public static readonly StyledProperty<string> FilePathProperty 
            = AvaloniaProperty.Register<TailView, string>(nameof(FilePath), notifying: OnFilePathChanged);

        public TailView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private static void OnFilePathChanged(IAvaloniaObject source, bool status)
        {
            if (!(source is TailView instance))
                return;

            var fileInfo = new FileInfo(instance.FilePath);
            instance.SetModel(fileInfo);
        }

        internal void SetModel(FileInfo fileInfo)
        {
            var factory = ServiceLocator.Default.Get<TailViewModelFactory>();
            var headeredView = factory.Create(fileInfo);

            var viewModel = (TailViewModel)headeredView.Content;
            DataContext = viewModel;

            //TODO: Remove it after integrating with virtual scroll viewer
            var scroller = (IScrollReceiver) viewModel;
            scroller.ScrollBoundsChanged(new ScrollBoundsArgs(88, 0));
        }
    }
}
