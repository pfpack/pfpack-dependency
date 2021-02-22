#nullable enable

using System;

namespace PrimeFuncPack
{
    public static partial class ServiceProviderExtensions
    {
        private static InvalidCastException CreateUnexpectedServiceTypeException(
            Type expected,
            Type actual)
            =>
            new InvalidCastException(
                $"Service type was expected to be {expected} but it was {actual}.");

        private static InvalidOperationException CreateNoServiceRegisteredException(
            Type serviceType)
            =>
            new InvalidOperationException(
                $"Service {serviceType} can not be resolved by service provider.");
    }
}