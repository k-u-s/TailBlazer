using DynamicData;
using TailBlazer.Domain.FileHandling.Search;

namespace TailBlazer.LogViewer.Views.Formatting
{
    public interface IIconProvider
    {
        IObservableList<IconDescription> Icons { get; }

        IDefaultIconSelector DefaultIconSelector { get; }
    }
}