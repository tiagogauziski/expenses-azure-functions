using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;

namespace Expenses.AzureFunctions.Application.Services.Expense
{
    public interface IExpenseCategoryService
    {
        Task<Domain.ExpenseCategory> CreateAsync(CreateExpenseCategoryCommand command);

        Task<Domain.ExpenseCategory> UpdateAsync(UpdateExpenseCategoryCommand command);

        Task<Domain.ExpenseCategory> GetByIdAsync(string id);
    }
}
