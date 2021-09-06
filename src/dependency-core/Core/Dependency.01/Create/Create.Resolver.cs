#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public static Dependency<T> Create(
            Func<IServiceProvider, T> single)
            =>
            new(
                single ?? throw new ArgumentNullException(nameof(single)));
    }
}