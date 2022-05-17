using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    public static Dependency<T> From(
        Func<T> single)
        =>
        new(
            single ?? throw new ArgumentNullException(nameof(single)));
}