#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class DependencyPipeline<T>
    {
        public T Resolve(IServiceProvider serviceProvider)
            =>
            resolver.Invoke(
                serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider)));
    }
}