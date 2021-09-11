#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency<T>
    {
        //[Obsolete(ObsoleteMessage.OneDependencyCreateIsObsolete, false)]
        public static Dependency<T> Create(
            Func<IServiceProvider, T> single)
            =>
            new(
                single ?? throw new ArgumentNullException(nameof(single)));
    }
}