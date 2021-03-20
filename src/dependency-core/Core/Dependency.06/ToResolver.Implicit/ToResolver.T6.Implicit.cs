#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public static implicit operator Func<IServiceProvider, T6>(
            Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            Pipeline.Pipe(
                dependency ?? throw new ArgumentNullException(nameof(dependency)))
            .sixthResolver;
    }
}