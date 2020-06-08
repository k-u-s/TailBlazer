using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using StructureMap;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.LogViewer.Infrastucture;

namespace TailBlazer.LogViewer
{
    public class ServiceLocator
    {
        private static Lazy<Container> _containerLazy = new Lazy<Container>(() => BaseServiceLocator.ContainerFactory(DispatcherProvider));
        public static Container Container = _containerLazy.Value;
        private static Lazy<IObjectProvider> _defaultLazy = new Lazy<IObjectProvider>(ObjectProviderFactory);
        public static IObjectProvider Default => _defaultLazy.Value;

        public static IObjectProvider ObjectProviderFactory() => Container.GetInstance<IObjectProvider>();

        private static IScheduler DispatcherProvider()
        {
            var tempWindowToGetDispatcher = new Window();
            var dispatcher = tempWindowToGetDispatcher.Dispatcher;
            var mainScheduler = new DispatcherScheduler(dispatcher);
            tempWindowToGetDispatcher.Close();
            return mainScheduler;
        }
    }
}
