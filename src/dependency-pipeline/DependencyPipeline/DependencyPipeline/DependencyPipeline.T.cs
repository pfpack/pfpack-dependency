#nullable enable

namespace PrimeFuncPack
{
    public sealed partial class DependencyPipeline<T>
    {
        private readonly Resolver<T> resolver;

        internal DependencyPipeline(in Resolver<T> resolver)
            => this.resolver = resolver;
    }
}