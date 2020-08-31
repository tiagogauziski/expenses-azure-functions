using System;

namespace Expenses.AzureFunctions.Application.Commands
{
    public class CreateExpenseCategoryCommand
    {
        public string Name { get; set; }

        public string Category { get; set; }
    }
}
