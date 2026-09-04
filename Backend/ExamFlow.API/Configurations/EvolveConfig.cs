using EvolveDb;
using Microsoft.Data.SqlClient;

namespace RestWithASPNET10alisson.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                var connectionString =
                    configuration["ConnectionStrings:MSSQLConnectionString"];

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException(
                        "Connection string 'MSSQLConnectionString' não encontrada");
                }

                try
                {
                    CriarBancoSeNaoExistir(connectionString);

                    using var evolveConnection =
                        new SqlConnection(connectionString);

                    var evolve = new Evolve(evolveConnection)
                    {
                        Locations = new List<string>
                        {
                            "db/migrations",
                            "db/dataset"
                        },

                        IsEraseDisabled = true
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            return services;
        }

        private static void CriarBancoSeNaoExistir(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);

            var databaseName = builder.InitialCatalog;

            builder.InitialCatalog = "master";

            using var connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            var databaseNameSeguro = databaseName.Replace("]", "]]");

            var sql = $"""
                IF DB_ID(N'{databaseName.Replace("'", "''")}') IS NULL
                BEGIN
                    CREATE DATABASE [{databaseNameSeguro}]
                END
                """;

            using var command = new SqlCommand(sql, connection);

            command.ExecuteNonQuery();
        }
    }
}