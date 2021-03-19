#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class ServiceProviderExtensions
    {
        public static T GetServiceOrThrow<T>(
            this IServiceProvider serviceProvider)
            where T : notnull
            =>
            InternalGetServiceOrThrow<T>(
                serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider)));

        private static T InternalGetServiceOrThrow<T>(
            IServiceProvider serviceProvider)
            where T : notnull
        {
            var service = serviceProvider.GetService(typeof(T));

            if(service is not null)
            {
                return (T)service;
            }

            throw new InvalidOperationException($"A service of type {typeof(T)} can not be resolved by the service provider.");
        }
    }
}