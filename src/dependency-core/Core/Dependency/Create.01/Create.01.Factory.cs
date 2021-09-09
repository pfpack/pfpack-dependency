#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T> Create<T>(
            Func<T> single)
            =>
            Dependency<T>.InternalCreate(
                single ?? throw new ArgumentNullException(nameof(single)));
    }
}