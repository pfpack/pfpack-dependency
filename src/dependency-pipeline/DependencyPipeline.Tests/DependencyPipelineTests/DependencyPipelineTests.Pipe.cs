#nullable enable

using Moq;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyPipelineTests
    {
        [Fact]
        public void Pipe_PipeFunctionIsNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(PlusFifteenIdRefType);
            var pipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            Func<RefType, StructType> pipeFunc = null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = pipeline.Pipe(pipeFunc));

            Assert.Equal("pipeFunc", ex.ParamName);
        }

        [Fact]
        public void Pipe_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(SomeTextStructType);
            var sourcePipeline = new DependencyPipeline<StructType>(mockResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.Pipe(_ => MinusFifteenIdRefType);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypeTestSource), MemberType = typeof(TestEntitySource))]
        public void Pipe_ThenResolve_ExpectCallPipeFuncOnce(
            in RefType? sourceValue)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new DependencyPipeline<RefType?>(mockResolver.Object.Resolve);

            var mockPipeFunc = MockFuncFactory.CreateMockFunc<RefType?, StructType>(SomeTextStructType);
            var actualPipeline = sourcePipeline.Pipe(mockPipeFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            var expectedValue = sourceValue;
            mockPipeFunc.Verify(f => f.Invoke(expectedValue), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypeTestSource), MemberType = typeof(TestEntitySource))]
        public void Pipe_ThenResolve_ExpectMappedValue(
            in StructType mappedValue)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(ZeroIdRefType);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockPipeFunc = MockFuncFactory.CreateMockFunc<RefType, StructType>(mappedValue);
            var actualPipeline = sourcePipeline.Pipe(mockPipeFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(mappedValue, actual);
        }
    }
}
