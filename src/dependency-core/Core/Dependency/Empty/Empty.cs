using System;

namespace PrimeFuncPack;

partial class Dependency
{
    public static Dependency<Unit> Empty() => new(Unit.From);
}