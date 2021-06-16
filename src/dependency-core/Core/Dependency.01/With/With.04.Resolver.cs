#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<T, T2, T3, T4> With<T2, T3, T4>(
            Func<IServiceProvider, T2> second,
            Func<IServiceProvider, T3> third,
            Func<IServiceProvider, T4> fourth)
            =>
            InternalWith(
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)),
                fourth ?? throw new ArgumentNullException(nameof(fourth)));

        private Dependency<T, T2, T3, T4> InternalWith<T2, T3, T4>(
            Func<IServiceProvider, T2> secondResolver,
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver)
            =>
            new(
                resolver, secondResolver, thirdResolver, fourthResolver);
    }
}