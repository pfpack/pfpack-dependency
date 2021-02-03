#nullable enable

using System;

namespace PrimeFuncPack.Tests
{
    internal static class TestDependencyExtensions
    {
        public static T Resolve<T>(
            this Dependency<T> dependency,
            IServiceProvider serviceProvider)
            =>
            dependency.Pipe(d => (Func<IServiceProvider, T>)d).Invoke(serviceProvider);
        
        public static (T1 First, T2 Second) Resolve<T1, T2>(
            this Dependency<T1, T2> dependency,
            IServiceProvider serviceProvider)
            =>
            new ValueTuple<T1, T2>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(serviceProvider));

        public static (T1 First, T2 Second, T3 Third) Resolve<T1, T2, T3>(
            this Dependency<T1, T2, T3> dependency,
            IServiceProvider serviceProvider)
            =>
            new ValueTuple<T1, T2, T3>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T3>)d).Invoke(serviceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth) Resolve<T1, T2, T3, T4>(
            this Dependency<T1, T2, T3, T4> dependency,
            IServiceProvider serviceProvider)
            =>
            new ValueTuple<T1, T2, T3, T4>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T3>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T4>)d).Invoke(serviceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth, T5 Fifth) Resolve<T1, T2, T3, T4, T5>(
            this Dependency<T1, T2, T3, T4, T5> dependency,
            IServiceProvider serviceProvider)
            =>
            new ValueTuple<T1, T2, T3, T4, T5>(
                dependency.Pipe(d => (Func<IServiceProvider, T1>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T2>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T3>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T4>)d).Invoke(serviceProvider),
                dependency.Pipe(d => (Func<IServiceProvider, T5>)d).Invoke(serviceProvider));
    }
}