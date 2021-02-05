#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    public static class DependencyRegistrator
    {
        public static DependencyRegistrator<T> Create<T>(
            IServiceCollection services,
            Func<IServiceProvider, T> resolver)
            where T : class
            =>
            DependencyRegistrator<T>.InternalCreate(
                services ?? throw new ArgumentNullException(nameof(services)),
                resolver ?? throw new ArgumentNullException(nameof(resolver)));
    }
}