using System;
using System.Collections.Generic;
using System.Text;
using Expenses.AzureFunctions.Infrastructure.CosmosDB.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.AzureFunctions.Infrastructure.CosmosDB
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IExpenseRepository, ExpenseRepository>();

            return services;
        }
    }
}
