#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public static Dependency<T> Create(
            Func<T> single)
            =>
            InternalCreate(
                single ?? throw new ArgumentNullException(nameof(single)));

        internal static Dependency<T> InternalCreate(
            Func<T> single)
            =>
            new(
                _ => single.Invoke());
    }
}