using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace SQLConfigurationProvider;

public class SqlServerConfigurationProvider : ConfigurationProvider, IDisposable
{
    private SqlServerConfigurationSource _source { get; }

    private readonly Timer? _timer;

    public SqlServerConfigurationProvider(SqlServerConfigurationSource source)
    {
        _source = source;

        if (_source.ReloadPeriodically)
        {
            _timer = new Timer
            (
                callback: ReloadSettings,
                dueTime: TimeSpan.FromSeconds(10),
                period: TimeSpan.FromSeconds(_source.PeriodInSeconds),
                state: null
            );
        }
    }

    public override void Load()
    {
        using var connection = new SqlConnection(_source.ConnectionString);

        //TODO Just a sample of query and set prop
        var myConfigurationOnSQL = connection.Query("select * from 1").ToDictionary(x => (string)x.Key, x => (string)x.Value);
        Data = myConfigurationOnSQL;

    }

    private void ReloadSettings(object? state)
    {
        Load();
        OnReload();
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}