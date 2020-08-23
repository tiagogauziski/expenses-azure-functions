using System;

namespace Expenses.AzureFunctions.Application.Commands
{
    public class CreateExpenseCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
