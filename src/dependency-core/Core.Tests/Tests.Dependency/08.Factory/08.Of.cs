using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests;

partial class DependencyTest
{
    [Theory]
    [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
    public void Of_08_ExpectResolvedValuesAreEqualToSource(
        StructType sourceRest)
    {
        var sourceFirst = new[] { byte.MaxValue };
        var sourceSecond = default(string);
        var sourceThird = PlusFifteenIdRefType;
        var sourceFourth = false;
        var sourceFifth = long.MinValue;
        var sourceSixth = DateTimeKind.Unspecified;
        var sourceSeventh = ZeroIdNullNameRecord;

        var actual = Dependency.Of(
            sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh, sourceRest);

        var actualValue = actual.Resolve();

        var expectedValue = ((sourceFirst, sourceSecond, sourceThird, sourceFourth), (sourceFifth, sourceSixth, sourceSeventh, sourceRest));
        Assert.Equal(expectedValue, actualValue);
    }
}