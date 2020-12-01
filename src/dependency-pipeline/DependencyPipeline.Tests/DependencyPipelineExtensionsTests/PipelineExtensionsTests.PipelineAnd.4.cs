#nullable enable

using Moq;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class PipelineExtensionsTests
    {
        [Fact]
        public void AndFourth_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            DependencyPipeline<(RefType, int, DateTime, string)> sourcePipeline = null!;

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(SomeTextStructType);
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And(otherPipeline));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void AndFourth_OtherPipelineIsNull_ExpectArgumentNullException()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((PlusFifteenIdRefType, Zero, NullTextStructType, SomeString));
            var sourcePipeline = new DependencyPipeline<(RefType, int, StructType, string)>(mockSourceResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And<RefType, int, StructType, string, long>(null!));
            Assert.Equal("otherPipeline", ex.ParamName);
        }

        [Fact]
        public void AndFourth_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((PlusFifteenIdRefType, Zero, NullTextStructType, SomeString));
            var sourcePipeline = new DependencyPipeline<(RefType, int, StructType, string)>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(long.MinValue);
            var otherPipeline = new DependencyPipeline<long>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockSourceResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Fact]
        public void AndFourth_ThenResolve_ExpectCallResolveOtherOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((PlusFifteenIdRefType, Zero, NullTextStructType, SomeString));
            var sourcePipeline = new DependencyPipeline<(RefType, int, StructType, string)>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(new DateTime(2015, 1, 17));
            var otherPipeline = new DependencyPipeline<DateTime>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockOtherResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypeTestSource), MemberType = typeof(TestEntitySource))]
        public void AndFourth_ThenResolve_ExpectResolvedtupleValue(
            in StructType firstValue)
        {
            var secondValue = decimal.Zero;
            var thirdValue = new DateTime(2021, 5, 7);

            var fourthValue = SomeString;
            var sourceValue = (firstValue, secondValue, thirdValue, fourthValue);

            var mockSourceResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new DependencyPipeline<(StructType, decimal, DateTime, string)>(mockSourceResolver.Object.Resolve);

            var otherValue = MinusFifteenIdRefType;
            var mockOtherResolver = MockFuncFactory.CreateMockResolver(otherValue);
            var otherPipeline = new DependencyPipeline<RefType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(firstValue, actual.First);
            Assert.Equal(secondValue, actual.Second);
            Assert.Equal(thirdValue, actual.Third);
            Assert.Equal(fourthValue, actual.Fourth);
            Assert.Equal(otherValue, actual.Fifth);
        }
    }
}
