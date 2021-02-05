#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace PrimeFuncPack
{
    partial class DependencyRegistrar<T>
    {
        public IServiceCollection RegisterScoped()
            =>
            services.AddScoped(resolver);
    }
}