using Microsoft.Extensions.Configuration;

namespace SQLConfigurationProvider;

public static partial class ServicesExtensions
{
    public static void AddSqlServerConfigurationSource(this IConfigurationBuilder configuration, string connectionStringName)
    {
        var connectionString = configuration.Build().GetConnectionString(connectionStringName);

        if (string.IsNullOrWhiteSpace(connectionString)) throw new InvalidProgramException($"{connectionStringName} is empty.");

        configuration.Sources.Add(new SqlServerConfigurationSource
        {
            ConnectionString = connectionString,
            ReloadPeriodically = true,
            PeriodInSeconds = 5
        });
    }
}
