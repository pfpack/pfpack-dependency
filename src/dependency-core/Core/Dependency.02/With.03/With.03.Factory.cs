#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public Dependency<T1, T2, T3> With<T3>(
            Func<T3> third)
            =>
            InnerWith(
                third ?? throw new ArgumentNullException(nameof(third)));

        private Dependency<T1, T2, T3> InnerWith<T3>(
            Func<T3> third)
            =>
            new(
                firstResolver,
                secondResolver,
                _ => third.Invoke());
    }
}