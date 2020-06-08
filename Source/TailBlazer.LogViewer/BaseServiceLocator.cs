using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
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
    public class BaseServiceLocator
    {
        public static Container ContainerFactory(Func<IScheduler> dispatcherProvider)
        {
            var container = new Container(x =>
            {
                x.AddRegistry<ControlRegistry>();
            });
            container.Configure(x => x.For<IScheduler>().Add(dispatcherProvider()));
            container.GetInstance<StartupController>();
            return container;
        }
    }
}
