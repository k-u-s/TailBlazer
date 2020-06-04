using System;
using System.Reactive.Concurrency;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;
using StructureMap;
using TailBlazer.Infrastucture;
using TailBlazer.Infrastucture.AppState;
using TailBlazer.Views.Layout;
using TailBlazer.Views.WindowManagement;
using TailBlazer.Domain.Infrastructure;

namespace TailBlazer.Application
{
    public class BootStrap
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();

        [STAThread]
        public static void Main(string[] args)
        {
            FreeConsole();

            var app = new global::TailBlazer.Application.App { ShutdownMode = ShutdownMode.OnLastWindowClose };
            app.InitializeComponent();

            app.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            var window = new MainWindow(args);
            app.ShutdownMode = ShutdownMode.OnLastWindowClose;
            app.Run(window);
        }
    }
}
