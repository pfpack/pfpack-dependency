﻿#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Infrastructure.Tests
{
    partial class BoxTests
    {
        [Test]
        [TestCaseSource(nameof(RefTypeTestSource))]
        public void New_ValueIsRefType_ExpectBoxValueIsSame(
            in RefType source)
        {
            var actual = new Box<RefType>(source);
            Assert.AreEqual(source, actual.Value);
        }

        [Test]
        public void New_ValueIsStruct_ExpectBoxValueIsSame()
        {
            var source = default(StructType);

            var actual = new Box<StructType>(source);
            Assert.AreEqual(source, actual.Value);
        }

        [Test]
        [TestCaseSource(nameof(RefTypeTestSource))]
        public void Of_ValueIsRefType_ExpectBoxValueIsSame(
            in RefType? source)
        {
            var actual = Box.Of(source);
            Assert.AreEqual(source, actual.Value);
        }

        [Test]
        public void Of_ValueIsStruct_ExpectBoxValueIsSame()
        {
            var source = SomeTextStructType;

            var actual = Box.Of(source);
            Assert.AreEqual(source, actual.Value);
        }
    }
}
