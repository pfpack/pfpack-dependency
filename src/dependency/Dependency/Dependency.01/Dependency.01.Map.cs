#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        public Dependency<TR> Map<TR>(
            Func<T, TR> map)
            =>
            InternalMap(
                map ?? throw new ArgumentNullException(nameof(map)));

        private Dependency<TR> InternalMap<TR>(
            Func<T, TR> map)
            =>
            Dependency<TR>.InternalCreate(
                sp => sp.Pipe(resolver).Pipe(map));
    }
}