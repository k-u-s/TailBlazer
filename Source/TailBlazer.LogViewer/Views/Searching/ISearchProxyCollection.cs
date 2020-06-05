using System;
using System.Collections.ObjectModel;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.LogViewer.Views.Searching;

namespace TailBlazer.Views.Searching
{
    public interface ISearchProxyCollection: IDisposable
    {
        IProperty<int> Count { get; }
        ReadOnlyObservableCollection<SearchOptionsProxy> Included { get; }
        ReadOnlyObservableCollection<SearchOptionsProxy> Excluded { get; }
        SearchProxyCollectionDropHandler PositionHandler { get; }
    }
}