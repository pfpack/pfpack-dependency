#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3, T4> With<T3, T4>(
            Func<T3> third,
            Func<T4> fourth)
            =>
            InnerWith(
                third ?? throw new ArgumentNullException(nameof(third)),
                fourth ?? throw new ArgumentNullException(nameof(fourth)));

        private Dependency<T1, T2, T3, T4> InnerWith<T3, T4>(
            Func<T3> third,
            Func<T4> fourth)
            =>
            new(
                firstResolver,
                secondResolver,
                _ => third.Invoke(),
                _ => fourth.Invoke());
    }
}