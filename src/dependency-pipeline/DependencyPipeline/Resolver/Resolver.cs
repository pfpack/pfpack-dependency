#nullable enable

using System;

namespace PrimeFuncPack
{
    public delegate T Resolver<out T>(IServiceProvider serviceProvider);
}
