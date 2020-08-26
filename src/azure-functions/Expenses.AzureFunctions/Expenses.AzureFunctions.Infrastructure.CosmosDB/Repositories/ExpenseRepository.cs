using System;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Domain.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace Expenses.AzureFunctions.Infrastructure.CosmosDB.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private const string ContainerName = "expense";
        private Container _container;

        public ExpenseRepository(
            CosmosClient dbClient,
            IOptions<CosmosDBOptions> cosmosDbOptions)
        {
            if (dbClient is null)
            {
                throw new ArgumentNullException(nameof(dbClient));
            }

            _container = dbClient.GetContainer(cosmosDbOptions.Value.DatabaseName, ContainerName);
        }

        public async Task CreateAsync(Expense model)
        {
            await _container.CreateItemAsync<Expense>(model, new PartitionKey(model.Id.ToString()));
        }
    }
}
