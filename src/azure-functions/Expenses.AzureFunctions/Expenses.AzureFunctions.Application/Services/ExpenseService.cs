using System;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;

namespace Expenses.AzureFunctions.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        public Task<bool> CreateExpenseAsync(CreateExpenseCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
                return Task.FromResult(false);

            if (command.Id == Guid.Empty)
                return Task.FromResult(false);

            return Task.FromResult(true);
        }
    }
}
