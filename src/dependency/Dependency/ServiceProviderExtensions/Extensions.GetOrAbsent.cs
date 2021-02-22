#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class ServiceProviderExtensions
    {
        public static Optional<T> GetServiceOrAbsent<T>(
            this IServiceProvider serviceProvider)
            where T : notnull
            =>
            InternalGetServiceOrAbsent<T>(
                serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider)));

        private static Optional<T> InternalGetServiceOrAbsent<T>(
            IServiceProvider serviceProvider)
            where T : notnull
            =>
            serviceProvider.GetService(typeof(T)) switch
            {
                T service
                => Optional.Present(service),

                null
                => Optional<T>.Absent,

                object invalid
                => throw CreateUnexpectedServiceTypeException(expected: typeof(T), actual: invalid.GetType())
            };
    }
}