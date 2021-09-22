using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithOneFactory_ThirdIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => SomeTextStructType, _ => MinusFifteenIdRefType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Func<RecordType>)null!));
            
            Assert.Equal("third", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneFactory_OthersAreNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RefType thirdValue)
        {
            var firstSource = LowerSomeTextStructType;
            var secondSource = PlusFifteenIdSomeStringNameRecord;

            var source = Dependency.From(_ => firstSource, _ => secondSource);

            var actual = source.With(() => thirdValue);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, thirdValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}