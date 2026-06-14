using FluentAssertions;
using NUnit.Framework;

namespace LSL.ExecuteIf.Tests;

public class ThenReturnTests
{
    [Test]
    public void GivenAValueToReturn_ThenItShouldReturnThatValue()
    {
        "no care".ThenReturn(12).Should().Be(12);
    }

    [Test]
    public void GivenAValueProvider_ThenItShouldReturnTheExpectedValue()
    {
        "no care".ThenReturn(_ => 12).Should().Be(12);
    }    
}