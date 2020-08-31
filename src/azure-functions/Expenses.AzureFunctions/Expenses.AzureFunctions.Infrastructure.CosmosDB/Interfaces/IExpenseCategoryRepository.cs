using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.AzureFunctions.Infrastructure.CosmosDB.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<Domain.ExpenseCategory> CreateAsync(Domain.ExpenseCategory model);
        Task<Domain.ExpenseCategory> UpdateAsync(Domain.ExpenseCategory model);
        Task<Domain.ExpenseCategory> GetByIdAsync(Guid id);
        Task<Domain.ExpenseCategory> GetByNameAsync(string name);
        Task<IReadOnlyList<Domain.ExpenseCategory>> GetListAsync();
    }
}
