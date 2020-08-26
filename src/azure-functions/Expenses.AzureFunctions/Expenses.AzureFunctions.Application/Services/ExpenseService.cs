using System;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;
using Expenses.AzureFunctions.Infrastructure.CosmosDB.Repositories;

namespace Expenses.AzureFunctions.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<bool> CreateExpenseAsync(CreateExpenseCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
                return false;

            if (command.Id == Guid.Empty)
                return false;

            await _expenseRepository.CreateAsync(new Domain.Models.Expense()
            {
                Id = command.Id.ToString(),
                Name = command.Name
            });

            return true;
        }
    }
}
