

using Microsoft.Extensions.DependencyInjection;
using MoneyMate.Core.Interfaces.Repositories;
using MoneyMate.Infrastructure.Repositories;

namespace MoneyMate.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBalanceRepository, BalanceRepository>();
            return services;
        }
    }
}
