using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class DependencyTest
    {
        [Fact]
        public void Obsolete_Create_07_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency);
            var methodName = nameof(Dependency.Create);

            var method = type.GetPublicStaticMethodOrThrow(methodName, 7);
            var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

            Assert.False(obsoleteAttribute.IsError);

            var expectedNewMethodName = nameof(Dependency.From);
            Assert.Contains(expectedNewMethodName, obsoleteAttribute.Message, StringComparison.InvariantCulture);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_07_FirstIsNull_ExpectArgumentNullException()
        {
            var second = PlusFifteen;
            var third = SomeTextStructType;
            var fourth = MinusFifteenIdSomeStringNameRecord;
            var fifth = DateTimeKind.Unspecified;
            var sixth = ZeroIdRefType;
            var seventh = LowerSomeString;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    NullRecordResolver,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("first", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_07_SecondIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var third = new object();
            var fourth = LowerSomeTextStructType;
            var fifth = long.MaxValue;
            var sixth = PlusFifteenIdLowerSomeStringNameRecord;
            var seventh = DateTimeKind.Local;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    NullRefResolver,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("second", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_07_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = PlusFifteenIdLowerSomeStringNameRecord;
            var second = new { Id = PlusFifteen };
            var fourth = UpperSomeString;
            var fifth = MinusFifteenIdRefType;
            var sixth = MinusFifteen;
            var seventh = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    NullStructResolver,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("third", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_07_FourthIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var second = DateTimeKind.Utc;
            var third = PlusFifteen;
            var fifth = WhiteSpaceString;
            var sixth = MinusFifteenIdRefType;
            var seventh = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    NullRefResolver,
                    _ => fifth,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_07_FifthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteenIdRefType;
            var second = PlusFifteenIdLowerSomeStringNameRecord;
            var third = TabString;
            var fourth = MinusFifteenIdRefType;
            var sixth = SomeTextStructType;
            var seventh = new object();

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    NullStructResolver,
                    _ => sixth,
                    _ => seventh));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_07_SixthIsNull_ExpectArgumentNullException()
        {
            var first = MinusFifteen;
            var second = MinusFifteenIdRefType;
            var third = PlusFifteenIdSomeStringNameRecord;
            var fourth = ThreeWhiteSpacesString;
            var fifth = byte.MaxValue;
            var seventh = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    NullRecordResolver,
                    _ => seventh));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_07_SeventhIsNull_ExpectArgumentNullException()
        {
            var first = SomeTextStructType;
            var second = new { Text = SomeString };
            var third = MinusFifteenIdRefType;
            var fourth = decimal.One;
            var fifth = LowerSomeString;
            var sixth = PlusFifteenIdLowerSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth,
                    NullRecordResolver));

            Assert.Equal("seventh", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Theory]
        [MemberData(nameof(TestEntitySource.StructTypes), MemberType = typeof(TestEntitySource))]
        public void Obsolete_Create_07_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            StructType sourceSeventh)
        {
            var sourceFirst = MinusFifteenIdSomeStringNameRecord;
            var sourceSecond = new { Id = PlusFifteen, Name = SomeString };
            var sourceThird = DateTimeKind.Unspecified;
            var sourceFourth = PlusFifteenIdRefType;
            var sourceFifth = MinusFifteen;
            var sourceSixth = WhiteSpaceString;

            var actual = Dependency.Create(
                _ => sourceFirst,
                _ => sourceSecond,
                _ => sourceThird,
                _ => sourceFourth,
                _ => sourceFifth,
                _ => sourceSixth,
                _ => sourceSeventh);

            var actualValue = actual.Resolve();

            var expectedValue = (sourceFirst, sourceSecond, sourceThird, sourceFourth, sourceFifth, sourceSixth, sourceSeventh);
            Assert.Equal(expectedValue, actualValue);
        }
    }
}