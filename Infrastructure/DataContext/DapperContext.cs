using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string _connectioString = "Server = localhost;Port=5432;Database=HomeTaskWebApi_db;User Id=postgres;Password=11223344;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectioString);
    }
}
