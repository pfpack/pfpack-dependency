#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public static Dependency<T1, T2, T3> From(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third)
            =>
            InternalFrom(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)),
                third ?? throw new ArgumentNullException(nameof(third)));

        internal static Dependency<T1, T2, T3> InternalFrom(
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