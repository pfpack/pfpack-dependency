#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3> With<T3>(
            Func<IServiceProvider, T3> third)
            =>
            InternalWith(
                third ?? throw new ArgumentNullException(nameof(third)));

        private Dependency<T1, T2, T3> InternalWith<T3>(
            Func<IServiceProvider, T3> thirdResolver)
            =>
            new(
                firstResolver, secondResolver, thirdResolver);
    }
}