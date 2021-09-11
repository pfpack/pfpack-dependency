#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        //[Obsolete(ObsoleteMessage.DependencyCreateIsObsolete, false)]
        public static Dependency<T> Create<T>(
            Func<IServiceProvider, T> single)
            =>
            new(
                single ?? throw new ArgumentNullException(nameof(single)));
    }
}