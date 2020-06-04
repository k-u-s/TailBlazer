using System;
using System.ComponentModel;
using System.Linq;
using Dragablz;
using MahApps.Metro.Controls;
using TailBlazer.Views.WindowManagement;

namespace TailBlazer
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow(params string[] files)
        {
            InitializeComponent();

            var model = TailBlazerApp.Default.Get<WindowViewModel>();
            if(files?.Any() == true)
                model.OpenFiles(files);

            DataContext = model;

            Closing += (sender, e) =>
            {
                if (TabablzControl.GetIsClosingAsPartOfDragOperation(this)) return;

                var todispose = ((MainWindow)sender).DataContext as IDisposable;
                todispose?.Dispose();
            };

            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            var windowsModel = DataContext as WindowViewModel;
            windowsModel?.OnWindowClosing();
        }
    }
}
