using System;

namespace Expenses.AzureFunctions.Application.Commands
{
    public class UpdateExpenseCommand : CreateExpenseCommand
    {
        public Guid Id { get; set; }
    }
}
