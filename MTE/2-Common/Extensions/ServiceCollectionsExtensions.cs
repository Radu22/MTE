using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _3_Persistency.Implementations;

namespace _2_Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddEntityFrameworkSqlServer().AddDbContext<MTEContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
