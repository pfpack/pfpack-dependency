#nullable enable

using System;

namespace PrimeFuncPack
{
    partial class DependencyPipeline<T>
    {
        public DependencyPipeline<TResult> Pipe<TResult>(
            in Func<IServiceProvider, T, TResult> pipeFunc)
            =>
            InternalPipe(
                pipeFunc ?? throw new ArgumentNullException(nameof(pipeFunc)));

        internal DependencyPipeline<TResult> InternalPipe<TResult>(
            Func<IServiceProvider, T, TResult> pipeFunc)
            =>
            DependencyPipeline.InternalStart(
                sp => Resolve(sp) switch
                {
                    var value => pipeFunc.Invoke(sp, value)
                });
    }
}