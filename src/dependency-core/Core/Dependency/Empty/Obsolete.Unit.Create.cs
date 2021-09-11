#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        //[Obsolete(ObsoleteMessage.DependencyCreateEmptyIsObsolete, false)]
        public static Dependency<Unit> Create()
            =>
            new(Unit.From);
    }
}