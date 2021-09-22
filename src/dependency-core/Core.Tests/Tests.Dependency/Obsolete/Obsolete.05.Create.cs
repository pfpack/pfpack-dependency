using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Obsolete_Create_05_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency);
            var methodName = nameof(Dependency.Create);

            var method = type.GetPublicStaticMethodOrThrow(methodName, 5);
            var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

            Assert.False(obsoleteAttribute.IsError);

            var expectedNewMethodName = nameof(Dependency.From);
            Assert.Contains(expectedNewMethodName, obsoleteAttribute.Message, StringComparison.InvariantCulture);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_05_FirstIsNull_ExpectArgumentNullException()
        {
            var second = SomeTextStructType;
            var third = MinusFifteenIdNullNameRecord;
            var fourth = PlusFifteen;
            var fifth = LowerSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(NullStructResolver, _ => second, _ => third, _ => fourth, _ => fifth));

            Assert.Equal("first", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_05_SecondIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var third = MinusFifteenIdRefType;
            var fourth = PlusFifteen;
            var fifth = decimal.One;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(_ => first, NullRefResolver, _ => third, _ => fourth, _ => fifth));

            Assert.Equal("second", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_05_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdRefType;
            var second = int.MaxValue;
            var fourth = LowerSomeString;
            var fifth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(_ => first, _ => second, NullRecordResolver, _ => fourth, _ => fifth));

            Assert.Equal("third", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_05_FourthIsNull_ExpectArgumentNullException()
        {
            var first = new object();
            var second = SomeString;
            var third = decimal.One;
            var fifth = int.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(_ => first, _ => second, _ => third, NullStructResolver, _ => fifth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_05_FifthIsNull_ExpectArgumentNullException()
        {
            var first = new { Id = PlusFifteen };
            var second = SomeTextStructType;
            var third = decimal.MinusOne;
            var fourth = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(_ => first, _ => second, _ => third, _ => fourth, NullRefResolver));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_05_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceFifth)
        {
            var sourceFirst = LowerSomeTextStructType;
            var sourceSecond = ZeroIdNullNameRecord;
            var sourceThird = MinusFifteenIdRefType;
            var sourceFourth = MinusFifteenIdNullNameRecord;

            var actual = Dependency.Create(
                _ => sourceFirst, _ => sourceSecond, _ => sourceThird, _ => sourceFourth, _ => sourceFifth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}