#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    public static class DependencyRegistrationExtensions
    {
        public static DependencyRegistrator<T> ToRegistrator<T>(
            this Dependency<T> dependency,
            IServiceCollection services)
            where T : class
            =>
            new(
                services ?? throw new ArgumentNullException(nameof(services)),
                dependency ?? throw new ArgumentNullException(nameof(dependency)));
    }
}