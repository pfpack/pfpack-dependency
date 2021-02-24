#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Func<IServiceProvider, T> ToResolver()
            =>
            resolver;

        public static implicit operator Func<IServiceProvider, T>(
            Dependency<T> dependency)
            =>
            Pipeline.Pipe(
                dependency ?? throw new ArgumentNullException(nameof(dependency)))
            .resolver;
    }
}