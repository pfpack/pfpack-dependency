#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public Func<IServiceProvider, T4> ToFourthResolver()
            =>
            fourthResolver;
        
        public static implicit operator Func<IServiceProvider, T4>(
            Dependency<T1, T2, T3, T4> dependency)
            =>
            Pipeline.Pipe(
                dependency ?? throw new ArgumentNullException(nameof(dependency)))
            .fourthResolver;
    }
}