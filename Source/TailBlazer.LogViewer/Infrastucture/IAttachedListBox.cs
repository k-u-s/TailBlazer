using System;
using System.Collections.Generic;
using System.Windows.Controls;
using DynamicData;
using TailBlazer.LogViewer.Views.Tail;

namespace TailBlazer.LogViewer.Infrastucture
{
    public interface IAttachedListBox
    {
        void Receive(ListBox selector);
    }


    public interface ISelectionMonitor: IDisposable
    {
        string GetSelectedText();

        IEnumerable<string> GetSelectedItems();

        IObservableList<LineProxy> Selected { get; }
    }
}