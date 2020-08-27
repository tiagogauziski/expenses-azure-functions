using System;

namespace Expenses.AzureFunctions.Application.Commands
{
    public class CreateExpenseCommand
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }
}
