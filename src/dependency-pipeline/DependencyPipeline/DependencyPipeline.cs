#nullable enable

using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PrimeFuncPack.DependencyPipeline.Tests")]

namespace PrimeFuncPack
{
    public static class DependencyPipeline
    {
        public static DependencyPipeline<Unit> Start()
            =>
            InternalStart(
                _ => Unit.Value);

        public static DependencyPipeline<T> Start<T>(
            in T sourceValue)
            =>
            sourceValue switch
            {
                var resolved => InternalStart(_ => resolved)
            };

        public static DependencyPipeline<T> Start<T>(
            in Resolver<T> resolver)
            =>
            InternalStart(
                resolver ?? throw new ArgumentNullException(nameof(resolver)));

        internal static DependencyPipeline<T> InternalStart<T>(
            in Resolver<T> resolver)
            =>
            new DependencyPipeline<T>(resolver);
    }
}
