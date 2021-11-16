using System;

namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<T> From<T>(
        Func<T> single)
        =>
        Dependency<T>.InternalFrom(
            single ?? throw new ArgumentNullException(nameof(single)));
}