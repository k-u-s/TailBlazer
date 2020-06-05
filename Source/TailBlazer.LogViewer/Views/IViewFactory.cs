using TailBlazer.Domain.Settings;
using TailBlazer.LogViewer.Infrastucture;

namespace TailBlazer.LogViewer.Views
{

    public interface IViewModelFactory
    {
        HeaderedView Create(ViewState state);

        string Key { get; }
    }
}
