#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {   
        public static implicit operator Func<IServiceProvider, T2>(
            Dependency<T1, T2, T3, T4> dependency)
            =>
            Pipeline.Pipe(
                dependency ?? throw new ArgumentNullException(nameof(dependency)))
            .secondResolver;
    }
}