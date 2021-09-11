using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Tests
{
    partial class SixDependencyTest
    {
        [Fact]
        public void Obsolete_Create_ExpectMethodIsObsolete()
        {
            var type = typeof(Dependency<RefType?, object, bool, RecordType, StructType?, int?>);
            var methodName = nameof(Dependency<RefType?, object, bool, RecordType, StructType?, int?>.Create);

            var methodTypes = new[]
            {
                typeof(Func<IServiceProvider, RefType?>),
                typeof(Func<IServiceProvider, object>),
                typeof(Func<IServiceProvider, bool>),
                typeof(Func<IServiceProvider, RecordType>),
                typeof(Func<IServiceProvider, StructType?>),
                typeof(Func<IServiceProvider, int?>)
            };

            var method = type.GetPublicStaticMethodOrThrow(methodName, 0, methodTypes);
            var obsoleteAttribute = method.GetObsoleteAttributeOrThrow();

            Assert.False(obsoleteAttribute.IsError);

            var expectedInsteadMethodName = "Dependency<T1, T2, T3, T4, T5, T6>.From";
            Assert.Contains(expectedInsteadMethodName, obsoleteAttribute.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_FirstIsNull_ExpectArgumentNullException()
        {
            var second = EmptyString;
            var third = PlusFifteenIdRefType;
            var fourth = LowerSomeTextStructType;
            var fifth = MinusOne;
            var sixth = MinusFifteenIdSomeStringNameRecord;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<DateTimeKind, string?, RefType?, StructType?, int, RecordType>.Create(
                    null!,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("first", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_SecondIsNull_ExpectArgumentNullException()
        {
            var first = ZeroIdRefType;
            var third = SomeString;
            var fourth = default(StructType);
            var fifth = long.MinValue;
            var sixth = One;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<RefType?, RecordType, string, StructType, long, int>.Create(
                    _ => first,
                    null!,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("second", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_ThirdIsNull_ExpectArgumentNullException()
        {
            var first = new object();
            var second = LowerSomeTextStructType;
            var fourth = MinusFifteenIdNullNameRecord;
            var fifth = false;
            var sixth = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<object?, StructType?, long, RecordType, bool, RefType?>.Create(
                    _ => first,
                    _ => second,
                    null!,
                    _ => fourth,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("third", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_FourthIsNull_ExpectArgumentNullException()
        {
            var first = default(bool?);
            var second = PlusFifteenIdSomeStringNameRecord;
            var third = SomeTextStructType;
            var fifth = int.MinValue;
            var sixth = long.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<bool?, RecordType?, StructType, RefType, int, long?>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    null!,
                    _ => fifth,
                    _ => sixth));

            Assert.Equal("fourth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_FifthIsNull_ExpectArgumentNullException()
        {
            var first = LowerSomeString;
            var second = MinusFifteenIdRefType;
            var third = ZeroIdNullNameRecord;
            var fourth = default(object?);
            var sixth = SomeTextStructType;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<string, RefType?, RecordType, object?, DateTimeKind, StructType>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    null!,
                    _ => sixth));

            Assert.Equal("fifth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Fact]
        public void Obsolete_Create_SixthIsNull_ExpectArgumentNullException()
        {
            var first = new { Value = decimal.One };
            var second = MinusFifteenIdSomeStringNameRecord;
            var third = PlusFifteenIdRefType;
            var fourth = UpperSomeString;
            var fifth = true;

            var ex = Assert.Throws<ArgumentNullException>(
                () => _ = Dependency<object, RecordType?, RefType, string, bool, StructType>.Create(
                    _ => first,
                    _ => second,
                    _ => third,
                    _ => fourth,
                    _ => fifth,
                    null!));

            Assert.Equal("sixth", ex.ParamName);
        }

        [Obsolete(ObsoleteMessage.TestMethodObsolete)]
        [Theory]
        [InlineData(null)]
        [InlineData(Zero)]
        [InlineData(PlusFifteen)]
        public void Obsolete_Create_ResolversAreNotNull_ExpectResolvedValuesAreEqualToSource(
            int? sourceSixth)
        {
            var sourceFirst = MinusFifteenIdRefType;
            var sourceSecond = new { Name  = SomeString };
            var sourceThird = true;
            var sourceFourth = PlusFifteenIdLowerSomeStringNameRecord;
            var sourceFifth = LowerSomeTextStructType;

            var actual = Dependency<RefType?, object, bool, RecordType, StructType?, int?>.Create(
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