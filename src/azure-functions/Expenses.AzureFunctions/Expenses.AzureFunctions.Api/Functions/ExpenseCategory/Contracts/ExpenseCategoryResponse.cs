using System;

namespace Expenses.AzureFunctions.Api.Functions.Expense.Contracts
{
    public class ExpenseCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
