using System;

namespace TailBlazer.LogViewer.Views.DialogServices
{
    public interface IDialogCoordinator
    {
        void Show(IDialogViewModel view, object content, Action<object> onClosed);
        void Close();
    }
}