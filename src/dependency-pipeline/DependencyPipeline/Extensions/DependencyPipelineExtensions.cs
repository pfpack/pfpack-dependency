#nullable enable

using System;

namespace PrimeFuncPack
{
    public static class DependencyPipelineExtensions
    {
        public static DependencyPipeline<(TFirst First, TOther Second)> And<TFirst, TOther>(
            this DependencyPipeline<TFirst> sourcePipeline,
            in DependencyPipeline<TOther> otherPipeline)
            where TFirst : class
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.InternalPipe(
                (sp, first) => other.Resolve(sp) switch
                {
                    var otherValue => (first, otherValue)
                });
        }

        public static DependencyPipeline<(TFirst First, TSecond Second, TOther Third)> And<TFirst, TSecond, TOther>(
            this DependencyPipeline<(TFirst First, TSecond Second)> sourcePipeline,
            in DependencyPipeline<TOther> otherPipeline)
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.InternalPipe(
                (sp, value) => other.Resolve(sp) switch
                {
                    var otherValue => (value.First, value.Second, otherValue)
                });
        }

        public static DependencyPipeline<(TFirst First, TSecond Second, TThird Third, TOther Fourth)> And<TFirst, TSecond, TThird, TOther>(
            this DependencyPipeline<(TFirst First, TSecond Second, TThird Third)> sourcePipeline,
            in DependencyPipeline<TOther> otherPipeline)
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.InternalPipe(
                (sp, value) => other.Resolve(sp) switch
                {
                    var otherValue => (value.First, value.Second, value.Third, otherValue)
                });
        }

        public static DependencyPipeline<(TFirst First, TSecond Second, TThird Third, TFourth Fourth, TOther Fifth)> And<TFirst, TSecond, TThird, TFourth, TOther>(
            this DependencyPipeline<(TFirst First, TSecond Second, TThird Third, TFourth Fourth)> sourcePipeline,
            in DependencyPipeline<TOther> otherPipeline)
        {
            _ = sourcePipeline ?? throw new ArgumentNullException(nameof(sourcePipeline));
            var other = otherPipeline ?? throw new ArgumentNullException(nameof(otherPipeline));

            return sourcePipeline.InternalPipe(
                (sp, value) => other.Resolve(sp) switch
                {
                    var otherValue => (value.First, value.Second, value.Third, value.Fourth, otherValue)
                });
        }
    }
}
