using System;
using Moq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class ServiceProviderExtensionsTest
{
    [Fact]
    public void GetServiceOrAbsent_ServiceProviderIsNull_ExpectArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(
            () => _ = NullServiceProvider!.GetServiceOrAbsent<RefType>());

        Assert.Equal("serviceProvider", ex.ParamName);
    }

    [Fact]
    public void GetServiceOrAbsent_ServiceProviderIsNotNull_ExpectCallProviderGetServiceOnce()
    {
        var mockServiceProvider = CreateMockServiceProvider(MinusFifteenIdSomeStringNameRecord);
        var serviceProvider = mockServiceProvider.Object;

        _ = serviceProvider.GetServiceOrAbsent<RecordType>();
        mockServiceProvider.Verify(sp => sp.GetService(typeof(RecordType)), Times.Once);
    }

    [Fact]
    public void GetServiceOrAbsent_ProviderGetServiceReturnsNull_ExpectAbsent()
    {
        var mockServiceProvider = CreateMockServiceProvider(null);
        var serviceProvider = mockServiceProvider.Object;

        var actual = serviceProvider.GetServiceOrAbsent<StructType>();
        var expected = Optional<StructType>.Absent;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetServiceOrAbsent_ServiceResultCanNotBeCastToExpectedType_ExpectInvalidCastException()
    {
        var mockServiceProvider = CreateMockServiceProvider(PlusFifteen);
        var serviceProvider = mockServiceProvider.Object;

        _ = Assert.Throws<InvalidCastException>(
            () => _ = serviceProvider.GetServiceOrAbsent<RefType>());
    }

    [Fact]
    public void GetServiceOrAbsent_ServiceResultTypeIsSameAsExpected_ExpectSourceValue()
    {
        var sourceValue = LowerSomeTextStructType;
        var mockServiceProvider = CreateMockServiceProvider(sourceValue);
        var serviceProvider = mockServiceProvider.Object;

        var actual = serviceProvider.GetServiceOrAbsent<StructType>();
        var expected = Optional.Present(sourceValue);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetServiceOrAbsent_ServiceResultTypeCanBeCastToExpected_ExpectSourceValue()
    {
        var sourceValue = MinusFifteenIdNullNameRecord;
        var mockServiceProvider = CreateMockServiceProvider(sourceValue);
        var serviceProvider = mockServiceProvider.Object;

        var actual = serviceProvider.GetServiceOrAbsent<object>();
        var expected = Optional.Present<object>(sourceValue);

        Assert.Equal(expected, actual);
    }
}
