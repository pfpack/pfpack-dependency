#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4, T5, T6>
    {
        public T1 ResolveFirst(
            IServiceProvider serviceProvider)
            =>
            firstResolver.Invoke(serviceProvider);

        public T2 ResolveSecond(
            IServiceProvider serviceProvider)
            =>
            secondResolver.Invoke(serviceProvider);

        public T3 ResolveThird(
            IServiceProvider serviceProvider)
            =>
            thirdResolver.Invoke(serviceProvider);

        public T4 ResolveFourth(
            IServiceProvider serviceProvider)
            =>
            fourthResolver.Invoke(serviceProvider);

        public T5 ResolveFifth(
            IServiceProvider serviceProvider)
            =>
            fifthResolver.Invoke(serviceProvider);

        public T6 ResolveSixth(
            IServiceProvider serviceProvider)
            =>
            sixthResolver.Invoke(serviceProvider);
    }
}