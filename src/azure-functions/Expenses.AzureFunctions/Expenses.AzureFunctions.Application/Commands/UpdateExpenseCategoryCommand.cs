using System;

namespace Expenses.AzureFunctions.Application.Commands
{
    public class UpdateExpenseCategoryCommand : CreateExpenseCategoryCommand
    {
        public Guid Id { get; set; }
    }
}
