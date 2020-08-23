﻿#nullable enable

using System;

namespace PrimeFuncPack.DependencyPipeline
{
    partial interface IDependencyPipeline<T>
    {
        public T Resolve(IServiceProvider serviceProvider);
    }
}