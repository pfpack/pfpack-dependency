using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class OneDependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
    public void WithSix_ExpectResolvedValuesAreEqualToSourceAndOther(
        RecordType? lastValue)
    {
        var sourceValue = SomeTextStructType;
        var source = Dependency.From(_ => sourceValue);

        var secondValue = DateTimeKind.Utc;
        var thirdValue = new object();

        var fourthValue = PlusFifteenIdRefType;
        var fifthValue = true;

        var sixthValue = TabString;

        var actual = source.With(secondValue, thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
        var actualValue = actual.Resolve();

        var expectedValue = (sourceValue, secondValue, thirdValue, fourthValue, fifthValue, sixthValue, lastValue);
        Assert.Equal(expectedValue, actualValue);
    }
}
