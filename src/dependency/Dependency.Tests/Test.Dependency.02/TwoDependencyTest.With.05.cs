#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithThree_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => SomeTextStructType, _ => long.MaxValue);
            var other = null as Dependency<RecordType?, StructType, decimal>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(other!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void WithThree_OtherIsNotNull_ExpectResolvedValuesAreSameAsSourceAndOther(
            RefType? otherLast)
        {
            var firstSource = default(StructType);
            var secondSource = MinusFifteenIdNullNameRecord;
            var source = Dependency.Create(_ => firstSource, _ => secondSource);
            
            var otherFirst = decimal.One;
            var otherSecond = PlusFifteen;
            var other = Dependency.Create(_ => otherFirst, _ => otherSecond, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, otherFirst, otherSecond, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}