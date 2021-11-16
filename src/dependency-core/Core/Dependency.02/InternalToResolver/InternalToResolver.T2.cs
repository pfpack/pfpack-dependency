using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2>
{
    internal Func<IServiceProvider, T2> InternalToSecondResolver()
        =>
        secondResolver;
}