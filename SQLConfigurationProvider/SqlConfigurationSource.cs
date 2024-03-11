using Microsoft.Extensions.Configuration;

namespace SQLConfigurationProvider;

public class SqlServerConfigurationSource : IConfigurationSource
{
    public required string ConnectionString { get; init; }

    public bool ReloadPeriodically { get; init; }

    public int PeriodInSeconds { get; init; } = 5;

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new SqlServerConfigurationProvider(this);
}