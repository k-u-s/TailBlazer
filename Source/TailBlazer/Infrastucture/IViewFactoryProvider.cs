using DynamicData.Kernel;
using TailBlazer.LogViewer.Views;
using TailBlazer.Views;

namespace TailBlazer.Infrastucture
{
    public interface IViewFactoryProvider
    {
        Optional<IViewModelFactory> Lookup(string key);
    }
}