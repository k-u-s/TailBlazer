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
using TailBlazer.Infrastucture;
using TailBlazer.Infrastucture.KeyboardNavigation;
using TailBlazer.Views;
using TailBlazer.Views.Tail;

namespace TailBlazer.LogViewer
{
    public class ServiceLocator
    {
        private static Lazy<IObjectProvider> _defaultLazy = new Lazy<IObjectProvider>(ObjectProviderFactory);
        public static IObjectProvider Default => _defaultLazy.Value;

        public static IObjectProvider ObjectProviderFactory()
        {
            var tempWindowToGetDispatcher = new Window();
            var container = new Container(x =>
            {
                x.For<ILogger>().Use<NullLogger>();
                x.For<ILogFactory>().Use<NullLogFactory>();

                x.For<ISelectionMonitor>().Use<SelectionMonitor>();
                x.For<ISearchInfoCollection>().Use<SearchInfoCollection>();
                x.For<ISearchMetadataCollection>().Use<SearchMetadataCollection>().Transient();
                x.For<ICombinedSearchMetadataCollection>().Use<CombinedSearchMetadataCollection>().Transient();
                
                x.For<ITextFormatter>().Use<TextFormatter>().Transient();
                x.For<ILineMatches>().Use<LineMatches>();
                x.For<ISettingsStore>().Use<FileSettingsStore>().Singleton();
                x.For<IFileWatcher>().Use<FileWatcher>();


                x.For<ObjectProvider>().Singleton();
                x.Forward<ObjectProvider, IObjectProvider>();
                x.Forward<ObjectProvider, IObjectRegister>();

                x.For<ISelectionMonitor>().Use<SelectionMonitor>();
                x.For<TailViewModelFactory>().Use<TailViewModelFactory>().Singleton();

                x.For<IKeyboardNavigationHandler>().Use<KeyboardNavigationHandler>();

                x.Scan(scanner =>
                {
                    scanner.ExcludeType<ILogger>();

                    //to do, need a auto-exclude these from AppConventions
                    scanner.ExcludeType<SelectionMonitor>();
                    scanner.ExcludeType<SearchInfoCollection>();
                    scanner.ExcludeType<SearchMetadataCollection>();
                    scanner.ExcludeType<CombinedSearchMetadataCollection>();
                    scanner.ExcludeType<TextFormatter>();
                    scanner.ExcludeType<LineMatches>();

                    scanner.ExcludeType<FileWatcher>();
                    scanner.LookForRegistries();
                    scanner.Convention<AppConventions>();

                    scanner.AssemblyContainingType<ILogFactory>();
                    scanner.AssemblyContainingType<ServiceLocator>();
                });
            });
            container.Configure(x => x.For<Dispatcher>().Add(tempWindowToGetDispatcher.Dispatcher));
            container.GetInstance<StartupController>();
            tempWindowToGetDispatcher.Close();
            var provider = container.GetInstance<IObjectProvider>();

            return provider;
        }
    }
}
