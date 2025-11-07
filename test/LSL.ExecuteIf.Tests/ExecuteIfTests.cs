using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LSL.ExecuteIf.Tests;

public class ExecuteIfTests
{
    [TestCase(false, new[] { 1, 2, 5, 22 })]
    [TestCase(true, new[] { 1, 2, 3, 22 })]
    public void GivenAPredicate_ThenItShouldReturnTheExpectedValue(bool willExecute, int[] expectedValues)
    {
        var values = new List<int> { 1, 2 };
        values.ExecuteIf(() => willExecute, v => v.Add(3), v => v.Add(5))
            .Add(22);

        values.Should().BeEquivalentTo(expectedValues);
    }

    [Test]
    public void GivenANullPredicate_ThenItShouldThrowANullException()
    {
        new Action(() => "asd".ExecuteIf(null, null))
            .Should()
            .Throw<ArgumentNullException>()
            .And
            .ParamName
            .Should()
            .Be("predicate");
    }

    [Test]
    public void GivenANullAction_ThenItShouldThrowANullException()
    {
        new Action(() => "asd".ExecuteIf(true, null))
            .Should()
            .Throw<ArgumentNullException>()
            .And
            .ParamName
            .Should()
            .Be("actionToExecute");
    }
    [TestCase(false, new[] { 1, 2 })]
    [TestCase(true, new[] { 1, 2, 3 })]
    public void GivenACondition_ThenItShouldReturnTheExpectedValue(bool willExecute, int[] expectedValues)
    {
        var values = new List<int> { 1, 2 };
        values.ExecuteIf(willExecute, v => v.Add(3));

        values.Should().BeEquivalentTo(expectedValues);
    }    
}