#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class ServiceProviderExtensions
    {
        public static T GetServiceOrThrow<T>(this IServiceProvider serviceProvider)
            where T : notnull
            =>
            InnerGetServiceOrThrow<T>(
                serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider)));

        private static T InnerGetServiceOrThrow<T>(IServiceProvider serviceProvider)
            where T : notnull
        {
            var service = serviceProvider.GetService(typeof(T));

            if (service is not null)
            {
                return (T)service;
            }

            throw new InvalidOperationException($"A service of type {typeof(T)} cannot be resolved by the service provider.");
        }
    }
}