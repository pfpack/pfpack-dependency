using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class ServiceProviderExtensionsTest
    {
        [Fact]
        public void GetServiceOrThrow_ServiceProviderIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = NullServiceProvider!.GetServiceOrThrow<StructType>());

            Assert.Equal("serviceProvider", ex.ParamName);
        }

        [Fact]
        public void GetServiceOrThrow_ServiceProviderIsNotNull_ExpectCallProviderGetServiceOnce()
        {
            var mockServiceProvider = CreateMockServiceProvider(PlusFifteen);
            var serviceProvider = mockServiceProvider.Object;

            _ = serviceProvider.GetServiceOrThrow<int>();
            mockServiceProvider.Verify(sp => sp.GetService(typeof(int)), Times.Once);
        }

        [Fact]
        public void GetServiceOrThrow_ProviderGetServiceReturnsNull_ExpectInvalidOperationException()
        {
            var mockServiceProvider = CreateMockServiceProvider(null);
            var serviceProvider = mockServiceProvider.Object;

            var ex = Assert.Throws<InvalidOperationException>(
                () => _ = serviceProvider.GetServiceOrThrow<RecordType>());
            
            Assert.Contains(typeof(RecordType).Name, ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void GetServiceOrThrow_ServiceResultCanNotBeCastToExpectedType_ExpectInvalidCastException()
        {
            var mockServiceProvider = CreateMockServiceProvider(SomeString);
            var serviceProvider = mockServiceProvider.Object;

            _ = Assert.Throws<InvalidCastException>(
                () => _ = serviceProvider.GetServiceOrThrow<StructType>());
        }

        [Fact]
        public void GetServiceOrThrow_ServiceResultTypeIsSameAsExpected_ExpectSourceValue()
        {
            var sourceValue = PlusFifteenIdRefType;
            var mockServiceProvider = CreateMockServiceProvider(sourceValue);
            var serviceProvider = mockServiceProvider.Object;

            var actual = serviceProvider.GetServiceOrThrow<RefType>();
            Assert.Equal(sourceValue, actual);
        }

        [Fact]
        public void GetServiceOrThrow_ServiceResultTypeCanBeCastToExpected_ExpectSourceValue()
        {
            var sourceValue = SomeTextStructType;
            var mockServiceProvider = CreateMockServiceProvider(sourceValue);
            var serviceProvider = mockServiceProvider.Object;

            var actual = serviceProvider.GetServiceOrThrow<object>();
            Assert.Equal(sourceValue, actual);
        }
    }
}
