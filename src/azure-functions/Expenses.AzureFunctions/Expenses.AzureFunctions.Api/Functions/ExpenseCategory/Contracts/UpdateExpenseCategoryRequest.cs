using System;

namespace Expenses.AzureFunctions.Api.Functions.Expense.Contracts
{
    public class UpdateExpenseCategoryRequest : CreateExpenseCategoryRequest
    {
        public Guid Id { get; set; }
    }
}
