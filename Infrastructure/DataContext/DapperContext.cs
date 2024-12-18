namespace DapperContext;
using Npgsql;

public class DapperContext
{
    private readonly string connectionString = "Server=127.0.0.1;Port=5432;Database=skills;User Id=postgres;Password=12345;";
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }

}