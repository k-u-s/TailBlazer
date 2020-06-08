﻿using System.Reactive.Concurrency;
using System.Windows.Threading;
using TailBlazer.Domain.Infrastructure;

namespace TailBlazer.LogViewer.Infrastucture
{
    public class SchedulerProvider : ISchedulerProvider
    {
        public IScheduler MainThread { get; }

        public IScheduler Background { get; } = TaskPoolScheduler.Default;

        public SchedulerProvider(IScheduler mainScheduler)
        {
            MainThread = mainScheduler;
        }

    }
}