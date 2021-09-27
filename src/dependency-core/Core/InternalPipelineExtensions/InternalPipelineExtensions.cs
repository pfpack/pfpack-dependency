#nullable enable

namespace System
{
    internal static class InternalPipelineExtensions
    {
        // The pipe arg not null validation is skipped as the internal extension is expected to be called in the correct context
        internal static TResult InternalPipe<T, TResult>(this T value, Func<T, TResult> pipe)
            =>
            pipe.Invoke(value);
    }
}