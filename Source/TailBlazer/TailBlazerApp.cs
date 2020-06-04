using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;
using StructureMap;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.Infrastucture;
using TailBlazer.Infrastucture.AppState;
using TailBlazer.Views.Layout;
using TailBlazer.Views.WindowManagement;

namespace TailBlazer
{
    public class TailBlazerApp
    {
        private static Lazy<IObjectProvider> _defaultLazy = new Lazy<IObjectProvider>(CreateObjectProvider);
        public static IObjectProvider Default = _defaultLazy.Value;

        private static IObjectProvider CreateObjectProvider()
        {
            var tempWindowToGetDispatcher = new Window();

            var container = new Container(x => x.AddRegistry<AppRegistry>());
            container.Configure(x => x.For<Dispatcher>().Add(tempWindowToGetDispatcher.Dispatcher));
            container.GetInstance<StartupController>();
            tempWindowToGetDispatcher.Close();

            var layoutServce = container.GetInstance<ILayoutService>();
            var scheduler = container.GetInstance<ISchedulerProvider>();

            var appStatePublisher = container.GetInstance<IApplicationStatePublisher>();
            Application.Current.Exit += (sender, e) => appStatePublisher.Publish(ApplicationState.ShuttingDown);
            return container.GetInstance<IObjectProvider>();
        }
    }
}
