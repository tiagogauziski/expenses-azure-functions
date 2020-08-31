using System;

namespace Expenses.AzureFunctions.Api.Functions.Expense.Contracts
{
    public class CreateExpenseCategoryRequest
    {
        public string Name { get; set; }
    }
}
