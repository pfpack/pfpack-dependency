#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<T> Create<T>(
            Func<T> single)
            =>
            throw new NotImplementedException();
    }
}