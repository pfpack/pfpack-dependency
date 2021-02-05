#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    partial class DependencyRegistrator<T>
    {
        internal static DependencyRegistrator<T> InternalCreate(
            IServiceCollection services,
            Func<IServiceProvider, T> resolver)
            =>
            new DependencyRegistrator<T>(services, resolver);
    }
}