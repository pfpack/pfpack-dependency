#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    public sealed partial class DependencyRegistrator<T>
        where T : class
    {
        private readonly IServiceCollection services;

        private readonly Func<IServiceProvider, T> resolver;

        internal DependencyRegistrator(
            IServiceCollection services,
            Func<IServiceProvider, T> resolver)
        {
            this.services = services;
            this.resolver = resolver;
        }
    }
}