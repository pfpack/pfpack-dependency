#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T1, T2, T3>
    {
        public static Dependency<T1, T2, T3> Create(
            Func<T1> first,
            Func<T2> second,
            Func<T3> third)
            =>
            throw new NotImplementedException();
    }
}