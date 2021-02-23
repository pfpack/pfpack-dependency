#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public Func<IServiceProvider, T2> ToSecondResolver()
            =>
            secondResolver;
        
        public static implicit operator Func<IServiceProvider, T2>(
            Dependency<T1, T2, T3> dependency)
            =>
            InternalToSecondResolver(
                dependency ?? throw new ArgumentNullException(nameof(dependency)));

        private static Func<IServiceProvider, T2> InternalToSecondResolver(
            Dependency<T1, T2, T3> dependency)
            =>
            dependency.secondResolver;
    }
}