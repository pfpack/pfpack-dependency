#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace PrimeFuncPack
{
    partial class DependencyRegistrator<T>
    {
        public IServiceCollection RegisterScoped()
            =>
            services.AddScoped(resolver);

        public IServiceCollection RegisterTransient()
            =>
            services.AddTransient(resolver);

        public IServiceCollection RegisterSingleton()
            =>
            services.AddSingleton(resolver);
    }
}