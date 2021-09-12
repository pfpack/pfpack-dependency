using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class FiveDependencyTest
    {
        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void GetThird_ExpectResolvedValueIsEqualToThirdSource(
            RecordType? thirdSource)
        {
            var source = Dependency.From(
                _ => UpperSomeString,
                _ => SomeTextStructType,
                _ => thirdSource,
                _ => new object(),
                _ => MinusFifteenIdRefType);

            var actual = source.GetThird();

            var actualValue = actual.Resolve();
            Assert.Equal(thirdSource, actualValue);
        }
    }
}