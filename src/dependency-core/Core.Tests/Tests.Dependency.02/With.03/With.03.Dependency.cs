using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class TwoDependencyTest
    {
        [Fact]
        public void WithOneDependency_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.From(_ => MinusFifteen, _ => SomeTextStructType);

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With((Dependency<RefType>)null!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithOneDependency_OtherIsNotNull_ExpectResolvedValuesAreEqualToSourceAndOther(
            RecordType? otherValue)
        {
            var firstSource = ZeroIdRefType;
            var secondSource = SomeTextStructType;

            var source = Dependency.From(_ => firstSource, _ => secondSource);
            var other = Dependency.From(_ => otherValue);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (firstSource, secondSource, otherValue);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}