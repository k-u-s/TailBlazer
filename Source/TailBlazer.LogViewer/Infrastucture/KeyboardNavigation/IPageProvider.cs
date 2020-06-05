namespace TailBlazer.LogViewer.Infrastucture.KeyboardNavigation
{
    public interface IPageProvider
    {
        int PageSize { get; }
        int FirstIndex { get; }
    }
}
