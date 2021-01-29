#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    partial class DependencyPipelineInjectionExtensions
    {
        public static DependencyPipeline<TService> InjectScoped<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            (sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline)))
            .CompleteScoped(services ?? throw new ArgumentNullException(nameof(services))) switch
            {
                _ => InjectedDependencyPipeline.ContinueFromServiceProvider<TService>()
            };

        public static IServiceCollection CompleteScoped<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            InternalCompleteScoped(
                sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline)),
                services ?? throw new ArgumentNullException(nameof(services)));

        private static IServiceCollection InternalCompleteScoped<TService>(
            in DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            services.AddScoped(sourcePipeline.Resolve);
    }
}
