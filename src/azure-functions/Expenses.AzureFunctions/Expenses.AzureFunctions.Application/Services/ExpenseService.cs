using System;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;
using Expenses.AzureFunctions.Domain.Models;
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

        public async Task<Expense> CreateAsync(CreateExpenseCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
                return null;

            return await _expenseRepository.CreateAsync(new Domain.Models.Expense()
            {
                Id = Guid.NewGuid().ToString(),
                Name = command.Name,
                Category = command.Category
            }).ConfigureAwait(false);
        }

        public async Task<Expense> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || !Guid.TryParse(id, out var guid))
                return null;

            return await _expenseRepository.GetByIdAsync(guid).ConfigureAwait(false);
        }

        public async Task<Expense> UpdateAsync(UpdateExpenseCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
                return null;

            if (command.Id == Guid.Empty)
                return null;

            return await _expenseRepository.UpdateAsync(new Domain.Models.Expense()
            {
                Id = command.Id.ToString(),
                Name = command.Name,
                Category = command.Category
            }).ConfigureAwait(false);
        }
    }
}
