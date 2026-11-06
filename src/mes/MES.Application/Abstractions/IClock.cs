using System;
using System.Collections.Generic;
using System.Text;


namespace MES.Application.Abstractions;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
