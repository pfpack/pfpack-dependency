#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
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
    }
}