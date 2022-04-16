namespace System;

internal static class InternalPipelineExtensions
{
    internal static TResult InternalPipe<T, TResult>(this T value, Func<T, TResult> pipe)
        =>
        pipe.Invoke(value);
}
