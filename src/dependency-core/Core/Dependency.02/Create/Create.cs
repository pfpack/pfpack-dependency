#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public static Dependency<T1, T2> Create(
            Func<T1> first,
            Func<T2> second)
            =>
            InternalCreate(
                first ?? throw new ArgumentNullException(nameof(first)),
                second ?? throw new ArgumentNullException(nameof(second)));

        internal static Dependency<T1, T2> InternalCreate(
            Func<T1> first,
            Func<T2> second)
            =>
            new(
                _ => first.Invoke(),
                _ => second.Invoke());
    }
}