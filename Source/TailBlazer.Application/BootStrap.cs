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
using TailBlazer.LogViewer;

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


            var container = ServiceLocator.Container;
            container.Configure(x => x.AddRegistry<AppRegistry>());
            container.GetInstance<StartupController>();

            var factory = container.GetInstance<WindowFactory>();
            var window = factory.Create(args);
            var layoutServce = container.GetInstance<ILayoutService>();
            var scheduler = container.GetInstance<ISchedulerProvider>();
            scheduler.MainThread.Schedule(window.Show);

            var appStatePublisher = container.GetInstance<IApplicationStatePublisher>();
            app.Exit += (sender, e) => appStatePublisher.Publish(ApplicationState.ShuttingDown);

            app.Run();
        }
    }
}
