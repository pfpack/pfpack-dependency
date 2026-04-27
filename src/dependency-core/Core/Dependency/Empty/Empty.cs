using System;

namespace PrimeFuncPack;

partial class Dependency
{
    [Obsolete("This method is obsolete. Call Pipe instead.")]
    public static Dependency<Unit> Empty()
        =>
        new(default(Unit));
}
