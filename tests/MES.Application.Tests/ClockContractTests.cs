using System;
using System.Collections.Generic;
using System.Text;
using MES.Application.Abstractions;

namespace MES.Application.Tests;

public sealed class ClockContractTests
{
    [Fact]
    public void Clock_CanBeReplacedWithDeterministicTime()
    {
        var expected = new DateTimeOffset(
            2026, 11, 3, 12, 0, 0, TimeSpan.Zero);

        IClock clock = new FakeClock(expected);

        Assert.Equal(expected, clock.UtcNow);
    }

    private sealed class FakeClock(
        DateTimeOffset time) : IClock
    {
        public DateTimeOffset UtcNow => time;
    }
}
