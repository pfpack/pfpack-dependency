#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack
{
    partial class DependencyPipelineInjectionExtensions
    {
        public static DependencyPipeline<TService> InjectTransient<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            (sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline)))
            .CompleteTransient(services ?? throw new ArgumentNullException(nameof(services))) switch
            {
                _ => InjectedDependencyPipeline.ContinueFromServiceProvider<TService>()
            };

        public static IServiceCollection CompleteTransient<TService>(
            this DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            InternalCompleteTransient(
                sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline)),
                services ?? throw new ArgumentNullException(nameof(services)));

        private static IServiceCollection InternalCompleteTransient<TService>(
            in DependencyPipeline<TService> sourcePipeline,
            in IServiceCollection services)
            where TService : class
            =>
            services.AddTransient(sourcePipeline.Resolve);
    }
}
