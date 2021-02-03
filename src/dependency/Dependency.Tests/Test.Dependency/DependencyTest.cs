#nullable enable

using System;
using Moq;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Tests
{
    public sealed partial class DependencyTest
    {
        private static readonly Func<IServiceProvider, StructType> NullStructResolver = null!;

        private static readonly Func<IServiceProvider, RefType> NullRefResolver = null!;

        private static readonly Func<IServiceProvider, RecordType> NullRecordResolver = null!;

        private static IServiceProvider CreateServiceProvider()
            =>
            Mock.Of<IServiceProvider>();
    }
}