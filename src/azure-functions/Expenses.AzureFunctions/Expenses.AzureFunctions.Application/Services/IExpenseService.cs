using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;
using Expenses.AzureFunctions.Domain.Models;

namespace Expenses.AzureFunctions.Application.Services
{
    public interface IExpenseService
    {
        Task<Expense> CreateAsync(CreateExpenseCommand command);

        Task<Expense> UpdateAsync(UpdateExpenseCommand command);

        Task<Expense> GetByIdAsync(string id);
    }
}
