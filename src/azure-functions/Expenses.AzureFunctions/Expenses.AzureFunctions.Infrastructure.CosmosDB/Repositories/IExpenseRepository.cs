using System.Threading.Tasks;
using Expenses.AzureFunctions.Domain.Models;

namespace Expenses.AzureFunctions.Infrastructure.CosmosDB.Repositories
{
    public interface IExpenseRepository
    {
        Task CreateAsync(Expense model);
    }
}
