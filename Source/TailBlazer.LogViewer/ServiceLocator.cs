using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using StructureMap;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.Infrastucture;
using TailBlazer.Infrastucture.KeyboardNavigation;
using TailBlazer.Views;
using TailBlazer.Views.Tail;

namespace TailBlazer.LogViewer
{
    public static class ServiceLocator
    {
        private static Lazy<IObjectProvider> _defaultLazy = new Lazy<IObjectProvider>(ObjectProviderFactory);
        public static IObjectProvider Default => _defaultLazy.Value;

        public static IObjectProvider ObjectProviderFactory()
        {
            var tempWindowToGetDispatcher = new Window();
            var container = new Container(x =>
            {
                x.For<ObjectProvider>().Singleton();
                x.Forward<ObjectProvider, IObjectProvider>();
                x.Forward<ObjectProvider, IObjectRegister>();

                x.For<ISelectionMonitor>().Use<SelectionMonitor>();
                x.For<TailViewModelFactory>().Use<TailViewModelFactory>().Singleton();

                x.For<IKeyboardNavigationHandler>().Use<KeyboardNavigationHandler>();
            });
            container.Configure(x => x.For<Dispatcher>().Add(tempWindowToGetDispatcher.Dispatcher));
            tempWindowToGetDispatcher.Close();
            var provider = container.GetInstance<IObjectProvider>();
            return provider;
        }
    }
}
