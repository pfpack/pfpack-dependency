using System;

namespace PrimeFuncPack;

partial class Dependency<T>
{
    internal Func<IServiceProvider, T> InternalToResolver()
        =>
        resolver;
}