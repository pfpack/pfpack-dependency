#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<Unit> Create()
            =>
            new(Unit.From);
    }
}