using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Text;
using System.Windows.Threading;
using Avalonia.Controls;
using ReactiveUI;
using StructureMap;
using TailBlazer.Domain.Infrastructure;

namespace TailBlazer.LogViewer
{
    class ServiceLocator
    {
        private static Lazy<Container> _containerLazy = new Lazy<Container>(() => BaseServiceLocator.ContainerFactory(DispatcherProvider));
        public static Container Container = _containerLazy.Value;
        private static Lazy<IObjectProvider> _defaultLazy = new Lazy<IObjectProvider>(ObjectProviderFactory);
        public static IObjectProvider Default => _defaultLazy.Value;

        public static IObjectProvider ObjectProviderFactory() => Container.GetInstance<IObjectProvider>();

        private static IScheduler DispatcherProvider() => RxApp.MainThreadScheduler;
    }
}
