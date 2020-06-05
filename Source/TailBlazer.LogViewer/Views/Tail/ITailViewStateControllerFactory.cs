using System;
using TailBlazer.Domain.Annotations;

namespace TailBlazer.LogViewer.Views.Tail
{
    public interface ITailViewStateControllerFactory
    {
        IDisposable Create([NotNull] TailViewModel tailView, bool loadDefaults);
    }
}