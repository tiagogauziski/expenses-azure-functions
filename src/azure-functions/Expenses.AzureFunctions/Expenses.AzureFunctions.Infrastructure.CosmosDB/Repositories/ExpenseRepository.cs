using System;
using System.Collections.Generic;
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

        public async Task<Expense> CreateAsync(Expense model)
        {
            return await _container.CreateItemAsync<Expense>(model, new PartitionKey(model.Id.ToString()));
        }

        public async Task<Expense> GetByIdAsync(Guid id)
        {
            return await _container.ReadItemAsync<Expense>(id.ToString(), new PartitionKey(id.ToString()));
        }

        public Task<Expense> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Expense>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Expense> UpdateAsync(Expense model)
        {
            throw new NotImplementedException();
        }
    }
}
