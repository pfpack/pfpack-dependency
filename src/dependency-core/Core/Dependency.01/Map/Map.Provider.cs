#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<TResult> Map<TResult>(
            Func<IServiceProvider, T, TResult> map)
            =>
            InternalMap(
                map ?? throw new ArgumentNullException(nameof(map)));

        private Dependency<TResult> InternalMap<TResult>(
            Func<IServiceProvider, T, TResult> map)
            =>
            new(
                sp => sp.Pipe(resolver).Pipe(value => map.Invoke(sp, value)));
    }
}