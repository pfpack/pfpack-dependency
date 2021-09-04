#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public static Dependency<T> Create(
            Func<T> single)
            =>
            throw new NotImplementedException();
    }
}