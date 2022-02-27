using System;

namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<T> From<T>(
        Func<T> single)
        =>
        new(
            single ?? throw new ArgumentNullException(nameof(single)));
}