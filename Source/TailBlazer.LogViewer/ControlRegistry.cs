using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using TailBlazer.Domain.FileHandling;
using TailBlazer.Domain.FileHandling.Search;
using TailBlazer.Domain.Formatting;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.Domain.Settings;
using TailBlazer.LogViewer.Infrastucture;
using TailBlazer.LogViewer.Infrastucture.KeyboardNavigation;
using TailBlazer.LogViewer.Views.Tail;

namespace TailBlazer.LogViewer
{
    public class ControlRegistry : Registry
    {
        public ControlRegistry()
        {
            For<ILogger>().Use<NullLogger>();
            For<ILogFactory>().Use<NullLogFactory>();

            For<ISelectionMonitor>().Use<SelectionMonitor>();
            For<ISearchInfoCollection>().Use<SearchInfoCollection>();
            For<ISearchMetadataCollection>().Use<SearchMetadataCollection>().Transient();
            For<ICombinedSearchMetadataCollection>().Use<CombinedSearchMetadataCollection>().Transient();

            For<ITextFormatter>().Use<TextFormatter>().Transient();
            For<ILineMatches>().Use<LineMatches>();
            For<ISettingsStore>().Use<FileSettingsStore>().Singleton();
            For<IFileWatcher>().Use<FileWatcher>();


            For<ObjectProvider>().Singleton();
            Forward<ObjectProvider, IObjectProvider>();
            Forward<ObjectProvider, IObjectRegister>();

            For<ISelectionMonitor>().Use<SelectionMonitor>();
            For<TailViewModelFactory>().Use<TailViewModelFactory>().Singleton();

            For<IKeyboardNavigationHandler>().Use<KeyboardNavigationHandler>();

            Scan(scanner =>
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
                scanner.AssemblyContainingType<ControlRegistry>();
            });
        }
    }
}
