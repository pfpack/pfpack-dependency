#nullable enable

using System;

namespace PrimeFuncPack
{
    public sealed partial class Dependency<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly Func<IServiceProvider, T1> firstResolver;

        private readonly Func<IServiceProvider, T2> secondResolver;

        private readonly Func<IServiceProvider, T3> thirdResolver;

        private readonly Func<IServiceProvider, T4> fourthResolver;

        private readonly Func<IServiceProvider, T5> fifthResolver;

        private readonly Func<IServiceProvider, T6> sixthResolver;

        private readonly Func<IServiceProvider, T7> seventhResolver;

        internal Dependency(
            Func<IServiceProvider, T1> firstResolver,
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver,
            Func<IServiceProvider, T5> fifthResolver,
            Func<IServiceProvider, T6> sixthResolver,
            Func<IServiceProvider, T7> seventhResolver)
        {
            this.firstResolver = firstResolver;
            this.secondResolver = secondResolver;
            this.thirdResolver = thirdResolver;
            this.fourthResolver = fourthResolver;
            this.fifthResolver = fifthResolver;
            this.sixthResolver = sixthResolver;
            this.seventhResolver = seventhResolver;
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

        internal Func<IServiceProvider, T6> InternalSixthResolver
            =>
            sixthResolver;

        internal Func<IServiceProvider, T7> InternalSeventhResolver
            =>
            seventhResolver;
    }
}