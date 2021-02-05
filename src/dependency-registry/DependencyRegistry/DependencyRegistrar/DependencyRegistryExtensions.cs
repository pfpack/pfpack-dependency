#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    public static class DependencyRegistryExtensions
    {
        public static DependencyRegistrar<T> ToRegistrar<T>(
            this Dependency<T> dependency,
            IServiceCollection services)
            where T : class
            =>
            new(
                services ?? throw new ArgumentNullException(nameof(services)),
                dependency ?? throw new ArgumentNullException(nameof(dependency)));
    }
}