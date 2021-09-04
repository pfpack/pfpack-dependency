#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2>
    {
        public static Dependency<T1, T2> Create(
            Func<T1> first,
            Func<T2> second)
            =>
            throw new NotImplementedException();
    }
}