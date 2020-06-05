using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GongSolutions.Wpf.DragDrop;

namespace TailBlazer.LogViewer.Views.Searching
{
    public class OrderChangedEventArgs : EventArgs
    {
        public OrderChangedEventArgs(object[] previousOrder, object[] newOrder)
        {
            PreviousOrder = previousOrder;
            NewOrder = newOrder ?? throw new ArgumentNullException(nameof(newOrder));
        }

        public object[] PreviousOrder { get; }

        public object[] NewOrder { get; }
    }

    public class SearchProxyCollectionDropHandler : DefaultDropHandler
    {
        public event EventHandler<OrderChangedEventArgs> OrderChanged;

        public override void Drop(IDropInfo dropInfo)
        {
            var prevOrder = dropInfo.TargetCollection.OfType<object>().ToArray();
            var newOrder = prevOrder.ToList();
            newOrder.Remove(dropInfo.Data);
            if(newOrder.Count < dropInfo.InsertIndex)
                newOrder.Add(dropInfo.Data);
            else
                newOrder.Insert(dropInfo.InsertIndex, dropInfo.Data);

            OrderChanged?.Invoke(this, 
                new OrderChangedEventArgs(prevOrder, newOrder.ToArray()));
        }
    }
}
