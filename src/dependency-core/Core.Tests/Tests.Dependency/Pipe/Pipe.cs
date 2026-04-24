using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Tests;

partial class DependencyTest
{
    [Fact]
    public void Pipe_DependencyIsNull_ExpectArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(InnerTest);
        Assert.Equal("dependency", ex.ParamName);

        static void InnerTest()
            =>
            Dependency.Pipe<RefType>(null!);
    }

    [Theory]
    [MemberData(nameof(TestEntitySource.RefTypes), MemberType = typeof(TestEntitySource))]
    public void Pipe_DependencyIsNotNull_ExpectSameDependency(
        RefType sourceValue)
    {
        var source = Dependency.From(_ => sourceValue);
        var actual = Dependency.Pipe(source);

        Assert.Same(source, actual);
    }
}