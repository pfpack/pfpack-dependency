#nullable enable

using System;

namespace PrimeFuncPack
{
    public sealed partial class Dependency<T1, T2, T3, T4, T5>
    {
        private readonly Func<IServiceProvider, T1> firstResolver;

        private readonly Func<IServiceProvider, T2> secondResolver;

        private readonly Func<IServiceProvider, T3> thirdResolver;

        private readonly Func<IServiceProvider, T4> fourthResolver;

        private readonly Func<IServiceProvider, T5> fifthResolver;

        private Dependency(
            Func<IServiceProvider, T1> firstResolver,
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver,
            Func<IServiceProvider, T5> fifthResolver)
        {
            this.firstResolver = firstResolver;
            this.secondResolver = secondResolver;
            this.thirdResolver = thirdResolver;
            this.fourthResolver = fourthResolver;
            this.fifthResolver = fifthResolver;
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

        internal Func<IServiceProvider, T4> InternalFourthResolver
            =>
            fourthResolver;

        internal Func<IServiceProvider, T5> InternalFifthResolver
            =>
            fifthResolver;
    }
}