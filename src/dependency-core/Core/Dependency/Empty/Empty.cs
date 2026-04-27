using System;

namespace PrimeFuncPack;

partial class Dependency
{
    [Obsolete("This method is obsolete and will be removed in future versions")]
    public static Dependency<Unit> Empty()
        =>
        new(default(Unit));
}