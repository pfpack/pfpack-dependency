#nullable enable

using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class OneDependencyTest
    {
        [Fact]
        public void WithThree_OtherIsNull_ExpectArgumentNullException()
        {
            var source = Dependency.Create(_ => int.MaxValue);
            var other = null as Dependency<RefType?, RecordType?, StructType>;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = source.With(other!));
            
            Assert.Equal("other", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(TestEntitySource.RecordTypes), MemberType = typeof(TestEntitySource))]
        public void WithThree_OtherIsNotNull_ExpectResolvedValuesAreSameAsSource(
            RecordType otherLast)
        {
            var sourceValue = SomeTextStructType;
            var source = Dependency.Create(_ => sourceValue);
            
            var otherFirst = PlusFifteenIdRefType;
            var otherSecond = MinusFifteen;
            var other = Dependency.Create(_ => otherFirst, _ => otherSecond, _ => otherLast);

            var actual = source.With(other);
            var actualValue = actual.Resolve();

            var expectedValue = (sourceValue, otherFirst, otherSecond, otherLast);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}