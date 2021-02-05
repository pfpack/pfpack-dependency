#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace PrimeFuncPack
{
    partial class DependencyRegistrator<T>
    {
        public IServiceCollection RegisterScoped()
            =>
            services.AddScoped(resolver);
    }
}