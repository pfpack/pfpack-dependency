#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class Dependency
    {
        public static Dependency<Unit> Empty => DependencyEmpty.Value;

        private static class DependencyEmpty
        {
            public static readonly Dependency<Unit> Value = Create();
        }
    }
}