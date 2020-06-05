using DynamicData;
using TailBlazer.LogViewer.Views.Recent;

namespace TailBlazer.LogViewer.Views.Searching
{
    public interface IRecentSearchCollection
    {
        IObservableList<RecentSearch> Items { get; }

        void Add(RecentSearch file);

        void Remove(RecentSearch file);
    }
}
