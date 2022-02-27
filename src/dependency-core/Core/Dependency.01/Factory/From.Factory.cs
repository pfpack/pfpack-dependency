using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public static Dependency<T> From(
        Func<T> single)
        =>
        InternalFrom(
            single ?? throw new ArgumentNullException(nameof(single)));

    internal static Dependency<T> InternalFrom(
        Func<T> single)
        =>
        new(
            single);
}