#nullable enable

using System;

namespace PrimeFuncPack
{
    public sealed partial class Dependency<T1, T2>
    {
        private readonly Func<IServiceProvider, T1> firstResolver;
        
        private readonly Func<IServiceProvider, T2> secondResolver;

        private Dependency(
            Func<IServiceProvider, T1> firstResolver,
            Func<IServiceProvider, T2> secondResolver)
        {
            this.firstResolver = firstResolver;
            this.secondResolver = secondResolver;
        }

        internal Func<IServiceProvider, T1> InternalFirstResolver
            =>
            firstResolver;
        
        internal Func<IServiceProvider, T2> InternalSecondResolver
            =>
            secondResolver;
    }
}