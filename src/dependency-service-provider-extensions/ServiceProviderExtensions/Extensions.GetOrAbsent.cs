using System;

namespace PrimeFuncPack;

partial class ServiceProviderExtensions
{
    public static Optional<T> GetServiceOrAbsent<T>(this IServiceProvider serviceProvider)
        where T : notnull
        =>
        InnerGetServiceOrAbsent<T>(
            serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider)));

    private static Optional<T> InnerGetServiceOrAbsent<T>(IServiceProvider serviceProvider)
        where T : notnull
        =>
        serviceProvider.GetService(typeof(T)) is object service
        ? new((T)service)
        : default;
}
