#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    public static class DependencyRegistrar
    {
        public static DependencyRegistrar<T> Create<T>(
            IServiceCollection services,
            Func<IServiceProvider, T> resolver)
            where T : class
            =>
            new(
                services ?? throw new ArgumentNullException(nameof(services)),
                resolver ?? throw new ArgumentNullException(nameof(resolver)));
    }
}