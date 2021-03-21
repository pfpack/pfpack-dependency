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
            dependency.Resolve(ServiceProvider);
        
        public static (T1 First, T2 Second) Resolve<T1, T2>(
            this Dependency<T1, T2> dependency)
            =>
            new ValueTuple<T1, T2>(
                dependency.ResolveFirst(ServiceProvider),
                dependency.ResolveSecond(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third) Resolve<T1, T2, T3>(
            this Dependency<T1, T2, T3> dependency)
            =>
            new ValueTuple<T1, T2, T3>(
                dependency.ResolveFirst(ServiceProvider),
                dependency.ResolveSecond(ServiceProvider),
                dependency.ResolveThird(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth) Resolve<T1, T2, T3, T4>(
            this Dependency<T1, T2, T3, T4> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4>(
                dependency.ResolveFirst(ServiceProvider),
                dependency.ResolveSecond(ServiceProvider),
                dependency.ResolveThird(ServiceProvider),
                dependency.ResolveFourth(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth, T5 Fifth) Resolve<T1, T2, T3, T4, T5>(
            this Dependency<T1, T2, T3, T4, T5> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4, T5>(
                dependency.ResolveFirst(ServiceProvider),
                dependency.ResolveSecond(ServiceProvider),
                dependency.ResolveThird(ServiceProvider),
                dependency.ResolveFourth(ServiceProvider),
                dependency.ResolveFifth(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth, T5 Fifth, T6 Sixth) Resolve<T1, T2, T3, T4, T5, T6>(
            this Dependency<T1, T2, T3, T4, T5, T6> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4, T5, T6>(
                dependency.ResolveFirst(ServiceProvider),
                dependency.ResolveSecond(ServiceProvider),
                dependency.ResolveThird(ServiceProvider),
                dependency.ResolveFourth(ServiceProvider),
                dependency.ResolveFifth(ServiceProvider),
                dependency.ResolveSixth(ServiceProvider));

        public static (T1 First, T2 Second, T3 Third, T4 Fourth, T5 Fifth, T6 Sixth, T7 Seventh) Resolve<T1, T2, T3, T4, T5, T6, T7>(
            this Dependency<T1, T2, T3, T4, T5, T6, T7> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4, T5, T6, T7>(
                dependency.ResolveFirst(ServiceProvider),
                dependency.ResolveSecond(ServiceProvider),
                dependency.ResolveThird(ServiceProvider),
                dependency.ResolveFourth(ServiceProvider),
                dependency.ResolveFifth(ServiceProvider),
                dependency.ResolveSixth(ServiceProvider),
                dependency.ResolveSeventh(ServiceProvider));

        public static ((T1 First, T2 Second, T3 Third, T4 Fourth) Left, (T5 Fifth, T6 Sixth, T7 Seventh, TRest Eighth) Right) Resolve<T1, T2, T3, T4, T5, T6, T7, TRest>(
            this Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> dependency)
            =>
            (dependency.ResolveLeftHalf(), dependency.ResolveRightHalf());

        private static (T1 First, T2 Second, T3 Third, T4 Fourth) ResolveLeftHalf<T1, T2, T3, T4, T5, T6, T7, TRest>(
            this Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> dependency)
            =>
            new ValueTuple<T1, T2, T3, T4>(
                dependency.ResolveFirst(ServiceProvider),
                dependency.ResolveSecond(ServiceProvider),
                dependency.ResolveThird(ServiceProvider),
                dependency.ResolveFourth(ServiceProvider));

        private static (T5 Fifth, T6 Sixth, T7 Seventh, TRest Eighth) ResolveRightHalf<T1, T2, T3, T4, T5, T6, T7, TRest>(
            this Dependency<T1, T2, T3, T4, T5, T6, T7, TRest> dependency)
            =>
            new ValueTuple<T5, T6, T7, TRest>(
                dependency.ResolveFifth(ServiceProvider),
                dependency.ResolveSixth(ServiceProvider),
                dependency.ResolveSeventh(ServiceProvider),
                dependency.ResolveRest(ServiceProvider));
    }
}