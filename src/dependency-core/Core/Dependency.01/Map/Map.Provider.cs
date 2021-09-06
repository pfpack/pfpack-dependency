#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<TResult> Map<TResult>(
            Func<IServiceProvider, T, TResult> map)
            =>
            InnerMap(
                map ?? throw new ArgumentNullException(nameof(map)));

        private Dependency<TResult> InnerMap<TResult>(
            Func<IServiceProvider, T, TResult> map)
            =>
            new(
                sp => sp.Pipe(resolver).Pipe(value => map.Invoke(sp, value)));
    }
}