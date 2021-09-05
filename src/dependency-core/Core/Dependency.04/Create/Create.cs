#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3, T4>
    {
        public static Dependency<T1, T2, T3, T4> Create(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third,
            Func<T4> fourth)
            =>
            InternalCreate(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)),
                fourth ?? throw new ArgumentNullException(nameof(fourth)));

        internal static Dependency<T1, T2, T3, T4> InternalCreate(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third,
            Func<T4> fourth)
            =>
            new(
                _ => first.Invoke(),
                _ => second.Invoke(),
                _ => third.Invoke(),
                _ => fourth.Invoke());
    }
}