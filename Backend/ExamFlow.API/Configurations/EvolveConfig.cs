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
                var connectionString = configuration["ConnectionStrings:MSSQLConnectionString"];
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException("Connection string 'MSSQLServerSQLConnection' não encontrado");
                }
                try
                {
                    using var evolveConnection = new SqlConnection(connectionString);
                    var evolve = new Evolve(evolveConnection)
                    {
                        Locations = new List<string> { "db/migrations", "db/dataset" },
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
    }
}