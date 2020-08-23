using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;

namespace Expenses.AzureFunctions.Application.Services
{
    public interface IExpenseService
    {
        Task<bool> CreateExpenseAsync(CreateExpenseCommand command);
    }
}
