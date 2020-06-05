using TailBlazer.Infrastucture;
using TailBlazer.LogViewer.Infrastucture;

namespace TailBlazer.Views.WindowManagement
{
    public interface IViewOpener
    {
        void OpenView(HeaderedView headeredView);
    }
}