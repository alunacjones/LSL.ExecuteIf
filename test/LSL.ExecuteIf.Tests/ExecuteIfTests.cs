using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LSL.ExecuteIf.Tests;

public class ExecuteIfTests
{
    [TestCase(false, new[] { 1, 2 })]
    [TestCase(true, new[] { 1, 2, 3 })]
    public void GivenAPredicate_ThenItShouldReturnTheExpectedValue(bool willExecute, int[] expectedValues)
    {
        var values = new List<int> { 1, 2 };
        values.ExecuteIf(() => willExecute, v => v.Add(3));

        values.Should().BeEquivalentTo(expectedValues);
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