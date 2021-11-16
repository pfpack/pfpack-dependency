using System;

namespace PrimeFuncPack;

partial class Dependency
{
    // TODO: Change to method Empty() in v2.0
    public static Dependency<Unit> Empty => new(Unit.From);
}