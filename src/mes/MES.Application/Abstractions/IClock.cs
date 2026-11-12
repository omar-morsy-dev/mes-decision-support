
namespace MES.Application.Abstractions;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
