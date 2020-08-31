using System;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;
using Expenses.AzureFunctions.Infrastructure.CosmosDB.Interfaces;

namespace Expenses.AzureFunctions.Application.Services.Expense
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _expenseRepository;

        public ExpenseCategoryService(IExpenseCategoryRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<Domain.ExpenseCategory> CreateAsync(CreateExpenseCategoryCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Name))
                return null;

            return await _expenseRepository.CreateAsync(new Domain.ExpenseCategory()
            {
                Id = Guid.NewGuid().ToString(),
                Name = command.Name
            }).ConfigureAwait(false);
        }

        public async Task<Domain.ExpenseCategory> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || !Guid.TryParse(id, out var guid))
                return null;

            return await _expenseRepository.GetByIdAsync(guid).ConfigureAwait(false);
        }

        public async Task<Domain.ExpenseCategory> UpdateAsync(UpdateExpenseCategoryCommand command)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(command.Name))
                return null;

            if (command.Id == Guid.Empty)
                return null;

            // Advanced validation


            return await _expenseRepository.UpdateAsync(new Domain.ExpenseCategory()
            {
                Id = command.Id.ToString(),
                Name = command.Name
            }).ConfigureAwait(false);
        }
    }
}
