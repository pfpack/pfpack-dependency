using System;

namespace PrimeFuncPack;

partial class Dependency<T1, T2, T3, T4>
{
    internal Func<IServiceProvider, T3> InternalToThirdResolver()
        =>
        thirdResolver;
}