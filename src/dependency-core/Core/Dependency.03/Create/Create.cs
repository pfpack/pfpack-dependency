#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public static Dependency<T1, T2, T3> Create(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third)
            =>
            InternalCreate(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)));

        internal static Dependency<T1, T2, T3> InternalCreate(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third)
            =>
            new(
                _ => first.Invoke(),
                _ => second.Invoke(),
                _ => third.Invoke());
    }
}