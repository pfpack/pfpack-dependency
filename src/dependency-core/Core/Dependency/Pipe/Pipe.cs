using System;

namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<T> Pipe<T>(Dependency<T> dependency)
        =>
        dependency ?? throw new ArgumentNullException(nameof(dependency));
}