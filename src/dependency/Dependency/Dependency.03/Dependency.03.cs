#nullable enable

using System;

namespace PrimeFuncPack
{
    public sealed partial class Dependency<T1, T2, T3>
    {
        private readonly Func<IServiceProvider, T1> firstResolver;

        private readonly Func<IServiceProvider, T2> secondResolver;

        private readonly Func<IServiceProvider, T3> thirdResolver;

        internal Dependency(
            Func<IServiceProvider, T1> firstResolver,
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver)
        {
            this.firstResolver = firstResolver;
            this.secondResolver = secondResolver;
            this.thirdResolver = thirdResolver;
        }

        internal Func<IServiceProvider, T1> InternalFirstResolver
            =>
            firstResolver;
        
        internal Func<IServiceProvider, T2> InternalSecondResolver
            =>
            secondResolver;

        internal Func<IServiceProvider, T3> InternalThirdResolver
            =>
            thirdResolver;
    }
}