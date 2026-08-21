using ExamFlow.API.Context;
using Microsoft.EntityFrameworkCore;

namespace ExamFlow.API.Configurations
{
    public static class DataBaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration) {

            var stringConnection = configuration["ConnectionStrings:MSSQLConnectionString"];
            if (string.IsNullOrEmpty(stringConnection))
            {
                throw new ArgumentNullException("Connection string 'ConnectionStrings:MSSQLConnectionString' não encontrado");
            }
            services.AddDbContext<ExamFlowContext>(options =>
            options.UseSqlServer(stringConnection));
            
            return services;
        }
    }
}
