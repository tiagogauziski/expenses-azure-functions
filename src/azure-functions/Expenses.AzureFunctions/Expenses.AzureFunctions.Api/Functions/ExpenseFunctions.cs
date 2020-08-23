using System.IO;
using System.Threading.Tasks;
using Expenses.AzureFunctions.Application.Commands;
using Expenses.AzureFunctions.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Expenses.AzureFunctions.Api.Functions
{
    public class ExpenseFunctions
    {
        private readonly IExpenseService _expenseService;

        public ExpenseFunctions(IExpenseService expenseService)
        {
            _expenseService = expenseService ?? throw new System.ArgumentNullException(nameof(expenseService));
        }

        [FunctionName("CreateExpense")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "expense")] HttpRequest req,
            ILogger log)
        {
            var content = await new StreamReader(req.Body).ReadToEndAsync();

            CreateExpenseCommand command = JsonConvert.DeserializeObject<CreateExpenseCommand>(content);

            if (await _expenseService.CreateExpenseAsync(command).ConfigureAwait(false))
                return new OkObjectResult(command);
            else
                return new BadRequestObjectResult(new { error = "Invalid command!" });
        }
    }
}
