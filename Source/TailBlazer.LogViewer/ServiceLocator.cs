using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using StructureMap;
using TailBlazer.Domain.FileHandling;
using TailBlazer.Domain.FileHandling.Search;
using TailBlazer.Domain.Formatting;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.Domain.Settings;
using TailBlazer.LogViewer.Infrastucture;

namespace TailBlazer.LogViewer
{
    public class ServiceLocator
    {
        private static Lazy<Container> _containerLazy = new Lazy<Container>(ContainerFactory);
        public static Container Container = _containerLazy.Value;
        private static Lazy<IObjectProvider> _defaultLazy = new Lazy<IObjectProvider>(ObjectProviderFactory);
        public static IObjectProvider Default => _defaultLazy.Value;

        public static IObjectProvider ObjectProviderFactory() => Container.GetInstance<IObjectProvider>();

        public static Container ContainerFactory()
        {
            var tempWindowToGetDispatcher = new Window();
            var container = new Container(x =>
            {
                x.AddRegistry<ControlRegistry>();
            });
            container.Configure(x => x.For<Dispatcher>().Add(tempWindowToGetDispatcher.Dispatcher));
            container.GetInstance<StartupController>();
            tempWindowToGetDispatcher.Close();
            return container;
        }
    }
}
