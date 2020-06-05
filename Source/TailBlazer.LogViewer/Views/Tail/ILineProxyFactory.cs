using TailBlazer.Domain.FileHandling;

namespace TailBlazer.LogViewer.Views.Tail
{
    public interface ILineProxyFactory
    {
        LineProxy Create(Line line);
    }
}