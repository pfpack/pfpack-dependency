#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    partial class DependencyPipelineInjectionExtensions
    {
        public static DependencyPipeline<TService> InjectSingleton<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            (sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline)))
            .CompleteSingleton(services ?? throw new ArgumentNullException(nameof(services))) switch
            {
                _ => InjectedDependencyPipeline.ContinueFromServiceProvider<TService>()
            };

        public static IServiceCollection CompleteSingleton<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            InternalCompleteSingleton(
                sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline)),
                services ?? throw new ArgumentNullException(nameof(services)));

        private static IServiceCollection InternalCompleteSingleton<TService>(
            in DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            services.AddSingleton(sourcePipeline.Resolve);
    }
}
