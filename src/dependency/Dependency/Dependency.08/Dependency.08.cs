#nullable enable

using System;

namespace PrimeFuncPack
{
    public sealed partial class Dependency<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly Func<IServiceProvider, T1> firstResolver;

        private readonly Func<IServiceProvider, T2> secondResolver;

        private readonly Func<IServiceProvider, T3> thirdResolver;

        private readonly Func<IServiceProvider, T4> fourthResolver;

        private readonly Func<IServiceProvider, T5> fifthResolver;

        private readonly Func<IServiceProvider, T6> sixthResolver;

        private readonly Func<IServiceProvider, T7> seventhResolver;

        private readonly Func<IServiceProvider, T8> eighthResolver;

        internal Dependency(
            Func<IServiceProvider, T1> firstResolver,
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver,
            Func<IServiceProvider, T5> fifthResolver,
            Func<IServiceProvider, T6> sixthResolver,
            Func<IServiceProvider, T7> seventhResolver,
            Func<IServiceProvider, T8> eighthResolver)
        {
            this.firstResolver = firstResolver;
            this.secondResolver = secondResolver;
            this.thirdResolver = thirdResolver;
            this.fourthResolver = fourthResolver;
            this.fifthResolver = fifthResolver;
            this.sixthResolver = sixthResolver;
            this.seventhResolver = seventhResolver;
            this.eighthResolver = eighthResolver;
        }
    }
}