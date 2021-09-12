using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Obsolete_Create_06_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency);
            var methodName = nameof(Dependency.Create);

            var method = type.GetPublicStaticMethodOrThrow(methodName, 6);
            var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

            Assert.False(obsoleteAttribute.IsError);

            var expectedNewMethodName = nameof(Dependency.From);
            Assert.Contains(expectedNewMethodName, obsoleteAttribute.Message, StringComparison.InvariantCulture);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_06_FirstIsNull_ExpectArgumentNullException()
        {
            var second = LowerSomeString;
            var third = MinusFifteenIdRefType;
            var fourth = SomeTextStructType;
            var fifth = MinusFifteen;
            var sixth = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    NullRecordResolver,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("first", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_06_SecondIsNull_ExpectArgumentNullException()
        {
            var first = new object();
            var third = PlusFifteen;
            var fourth = ZeroIdNullNameRecord;
            var fifth = UpperSomeString;
            var sixth = LowerSomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    NullRefResolver,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("second", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_06_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var second = Zero;
            var fourth = MinusFifteenIdSomeStringNameRecord;
            var fifth = LowerSomeString;
            var sixth = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    NullStructResolver,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("third", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_06_FourthIsNull_ExpectArgumentNullException()
        {
            var first = UpperSomeString;
            var second = long.MinValue;
            var third = MinusFifteenIdNullNameRecord;
            var fifth = new { Id = PlusFifteen };
            var sixth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    NullRefResolver,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_06_FifthIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeTextStructType;
            var second = UpperSomeString;
            var third = PlusFifteen;
            var fourth = EmptyString;
            var sixth = MinusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    NullStructResolver,
                    _ => sixth));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_06_SixthIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdLowerSomeStringNameRecord;
            var second = decimal.MinusOne;
            var third = UpperSomeString;
            var fourth = SomeTextStructType;
            var fifth = MinusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    NullRecordResolver));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Theory]
        [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_06_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            RefType? sourceSixth)
        {
            var sourceFirst = MinusFifteen;
            var sourceSecond = WhiteSpaceString;
            var sourceThird = new object();
            var sourceFourth = LowerSomeTextStructType;
            var sourceFifth = PlusFifteenIdLowerSomeStringNameRecord;

            var actual = Dependency.Create(
                _ => sourceFirst,
                _ => sourceSecond,
                _ => sourceThird,
                _ => sourceFourth,
                _ => sourceFifth,
                _ => sourceSixth);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}