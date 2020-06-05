using System;
using TailBlazer.Domain.Infrastructure;

namespace TailBlazer.Infrastucture
{
    public class NullLogFactory : ILogFactory
    {
        public ILogger Create(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return new NullLogger();
        }
        public ILogger Create<T>()
        {
            return new NullLogger();
        }
    }
}