using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.LogViewer;
using TailBlazer.Views.Tail;

namespace TailBlazer.Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public TailViewModel TailViewModel { get; set; }

        public MainWindow()
        {
            var filePath = "./Sample.txt";
            var fileInfo = new FileInfo(filePath);

            var factory = ServiceLocator.Default.Get<TailViewModelFactory>();
            var vieModel = factory.Create(fileInfo);

            TailViewModel = (TailViewModel)vieModel.Content;

            DataContext = this;
            InitializeComponent();
        }
    }
}
