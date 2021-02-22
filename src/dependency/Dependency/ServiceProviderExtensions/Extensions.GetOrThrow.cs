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
            =>
            serviceProvider.GetService(typeof(T)) switch
            {
                T service
                => service,

                null
                => throw CreateNoServiceRegisteredException(typeof(T)),

                object invalid
                => throw CreateUnexpectedServiceTypeException(expected: typeof(T), actual: invalid.GetType())
            };
    }
}