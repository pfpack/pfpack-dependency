using System;

namespace PrimeFuncPack;

partial class Dependency
{
    [Obsolete(ObsoleteMessage.DependencyCreateEmpty, ObsoleteError.DependencyCreate)]
    public static Dependency<Unit> Create()
        =>
        new(Unit.From);
}