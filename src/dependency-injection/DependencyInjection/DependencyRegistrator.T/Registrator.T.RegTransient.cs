#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace PrimeFuncPack
{
    partial class DependencyRegistrator<T>
    {
        public IServiceCollection RegisterTransient()
            =>
            services.AddTransient(resolver);
    }
}