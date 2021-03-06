#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public T3 ResolveThird(
            IServiceProvider serviceProvider)
            =>
            thirdResolver.Invoke(serviceProvider);
    }
}