#nullable enable

using System;
using static System.FormattableString;

namespace PrimeFuncPack
{
    internal static class InjectedDependencyPipeline
    {
        public static DependencyPipeline<T> ContinueFromServiceProvider<T>()
            where T : class
            =>
            DependencyPipeline.Start(ResolveFromServiceProvider<T>);

        private static T ResolveFromServiceProvider<T>(
            IServiceProvider serviceProvider)
            where T : class
            =>
            serviceProvider.GetService(typeof(T)) switch
            {
                T service => service,
                _ => throw CreateInstanceOfTypeCanNotBeResolvedException(typeof(T))
            };

        private static InvalidOperationException CreateInstanceOfTypeCanNotBeResolvedException(
            in Type typeName)
            =>
            new InvalidOperationException(
                    Invariant($"Instance of type '{typeName.FullName}' can't be resolved from service provider."));
    }
}
