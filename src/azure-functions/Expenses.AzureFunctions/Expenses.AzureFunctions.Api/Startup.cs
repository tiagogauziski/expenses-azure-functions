using Expenses.AzureFunctions.Application.Services.Expense;
using Expenses.AzureFunctions.Infrastructure.CosmosDB;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: FunctionsStartup(typeof(Expenses.AzureFunctions.Api.Startup))]

namespace Expenses.AzureFunctions.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<CosmosDBOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("CosmosDB").Bind(settings);
                });

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();

            builder.Services.AddRepositoryDependencies();

            builder.Services.AddSingleton((s) =>
            {
                var cosmosDbOptions = s.GetService<IOptions<CosmosDBOptions>>();

                CosmosClientBuilder cosmosClientBuilder = new CosmosClientBuilder(cosmosDbOptions.Value.ConnectionString);

                return cosmosClientBuilder
                    .WithApplicationRegion("Australia East")
                    .Build();
            });
        }
    }
}
