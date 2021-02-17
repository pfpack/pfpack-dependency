#nullable enable

using System;
using Moq;

namespace PrimeFuncPack.Tests
{
    internal static class TestDependencyExtensions
    {
        private static readonly IServiceProvider ServiceProvider = Mock.Of<IServiceProvider>();

        public static T Resolve<T>(
            this Dependency<T> dependency)
            =>
            dependency.Pipe(d => (Func<IServiceProvider, T>)d).Invoke(ServiceProvider);
        
        public static (T1 First, T2 Second) Resolve<T1, T2>(
            this Dependency<T1, T2> dependency)
            =>
            new ValueTuple<T1, T2>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third) Resolve<T1, T2, T3>(
            this Dependency<T1, T2, T3> dependency)
            =>
            new ValueTuple<T1, T2, T3>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T3>)d).Invoke(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth) Resolve<T1, T2, T3, T4>(
            this Dependency<T1, T2, T3, T4> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T3>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T4>)d).Invoke(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth, T5 Fifth) Resolve<T1, T2, T3, T4, T5>(
            this Dependency<T1, T2, T3, T4, T5> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4, T5>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T3>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T4>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T5>)d).Invoke(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth, T5 Fifth, T6 Sixth) Resolve<T1, T2, T3, T4, T5, T6>(
            this Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4, T5, T6>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T3>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T4>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T5>)d).Invoke(ServiceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T6>)d).Invoke(ServiceProvider));
    }
}