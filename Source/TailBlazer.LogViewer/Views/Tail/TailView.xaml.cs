using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TailBlazer.LogViewer.Views.Tail
{
    /// <summary>
    /// Interaction logic for TailView.xaml
    /// </summary>
    public partial class TailView : UserControl
    {
        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        public static readonly DependencyProperty FilePathProperty 
            = DependencyProperty.Register(
                nameof(FilePath), typeof(string),
                typeof(TailView), new UIPropertyMetadata("", OnFilePathChanged));

        public TailViewModel ViewModel
        {
            get { return (TailViewModel)GetValue(ViewModelProperty); }
            internal set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty
            = DependencyProperty.Register(
                nameof(ViewModel), typeof(TailViewModel),
                typeof(TailView));

        public TailView()
        {
            InitializeComponent();

            IsVisibleChanged += (sender, e) =>
            {
                FocusSearchTextBox();
            };            
        }

        private static void OnFilePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is TailView instance))
                return;

            var fileInfo = new FileInfo(instance.FilePath);

            var factory = ServiceLocator.Default.Get<TailViewModelFactory>();
            var vieModel = factory.Create(fileInfo);

            instance.ViewModel = (TailViewModel)vieModel.Content;
        }

        private void FocusSearchTextBox()
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                SearchTextBox.Focus();
                MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }));
        }

        private void ApplicationCommandFind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            FocusSearchTextBox();
        }
    }
}
