#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4> With<T3, T4>(
            Func<IServiceProvider, T3> third,
            Func<IServiceProvider, T4> fourth)
            =>
            InternalWith(
                third ?? throw new ArgumentNullException(nameof(third)),
                fourth ?? throw new ArgumentNullException(nameof(fourth)));

        private Dependency<T1, T2, T3, T4> InternalWith<T3, T4>(
            Func<IServiceProvider, T3> thirdResolver,
            Func<IServiceProvider, T4> fourthResolver)
            =>
            new(
                firstResolver, secondResolver, thirdResolver, fourthResolver);
    }
}