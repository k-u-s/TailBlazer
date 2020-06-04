using System;
using System.Collections.Generic;
using System.Linq;
using Dragablz;
using TailBlazer.Domain.Infrastructure;

namespace TailBlazer.Views.WindowManagement
{
    public class WindowFactory : IWindowFactory
    {
        public MainWindow Create(IEnumerable<string> files = null) => new MainWindow(files?.ToArray());
    }
}