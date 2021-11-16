using System;
using Xunit;

namespace PrimeFuncPack.Tests;

partial class DependencyTest
{
    [Fact]
    public void Empty_ExpectResolvedValueIsUnit()
    {
        var actual = Dependency.Empty();
        var actualValue = actual.Resolve();

        Assert.Equal(Unit.Value, actualValue);
    }

    [Fact]
    public void EmptyTwoTimes_ExpectDependenciesAreNotSame()
    {
        var firstDependency = Dependency.Empty();
        var secondDependency = Dependency.Empty();

        Assert.NotSame(firstDependency, secondDependency);
    }
}