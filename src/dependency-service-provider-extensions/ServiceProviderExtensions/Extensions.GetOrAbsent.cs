#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class ServiceProviderExtensions
    {
        public static Optional<T> GetServiceOrAbsent<T>(this IServiceProvider serviceProvider)
            where T : notnull
            =>
            InnerGetServiceOrAbsent<T>(
                serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider)));

        private static Optional<T> InnerGetServiceOrAbsent<T>(IServiceProvider serviceProvider)
            where T : notnull
        {
            var service = serviceProvider.GetService(typeof(T));

            if (service is not null)
            {
                return Optional<T>.Present((T)service);
            }

            return default;
        }
    }
}