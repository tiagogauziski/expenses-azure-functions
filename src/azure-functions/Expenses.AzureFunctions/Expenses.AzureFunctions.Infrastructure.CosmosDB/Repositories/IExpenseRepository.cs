using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Domain.Models;

namespace Expenses.AzureFunctions.Infrastructure.CosmosDB.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> CreateAsync(Expense model);
        Task<Expense> UpdateAsync(Expense model);
        Task<Expense> GetByIdAsync(Guid id);
        Task<Expense> GetByNameAsync(string name);
        Task<IReadOnlyList<Expense>> GetListAsync();
    }
}
