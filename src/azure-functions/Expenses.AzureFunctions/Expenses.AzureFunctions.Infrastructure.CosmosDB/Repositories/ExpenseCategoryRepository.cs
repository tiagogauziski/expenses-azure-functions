using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Infrastructure.CosmosDB.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace Expenses.AzureFunctions.Infrastructure.CosmosDB.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private const string ContainerName = "expenseCategory";
        private Container _container;

        public ExpenseCategoryRepository(
            CosmosClient dbClient,
            IOptions<CosmosDBOptions> cosmosDbOptions)
        {
            if (dbClient is null)
            {
                throw new ArgumentNullException(nameof(dbClient));
            }

            _container = dbClient.GetContainer(cosmosDbOptions.Value.DatabaseName, ContainerName);
        }

        public async Task<Domain.ExpenseCategory> CreateAsync(Domain.ExpenseCategory model)
        {
            return await _container.CreateItemAsync<Domain.ExpenseCategory>(model, new PartitionKey(model.Id.ToString()));
        }

        public async Task<Domain.ExpenseCategory> GetByIdAsync(Guid id)
        {
            return await _container.ReadItemAsync<Domain.ExpenseCategory>(id.ToString(), new PartitionKey(id.ToString()));
        }

        public Task<Domain.ExpenseCategory> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Domain.ExpenseCategory>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.ExpenseCategory> UpdateAsync(Domain.ExpenseCategory model)
        {
            throw new NotImplementedException();
        }
    }
}
