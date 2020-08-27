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
        public async Task<IActionResult> CreateExpense(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "expense")] HttpRequest req,
            ILogger log)
        {
            var content = await new StreamReader(req.Body).ReadToEndAsync();

            CreateExpenseCommand command = JsonConvert.DeserializeObject<CreateExpenseCommand>(content);

            var createResult = await _expenseService.CreateAsync(command).ConfigureAwait(false);

            if (createResult != null)
                return new OkObjectResult(createResult);
            else
                return new BadRequestObjectResult(new { error = "Invalid request!" });
        }

        [FunctionName("GetExpenseById")]
        public async Task<IActionResult> GetExpenseById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "expense/{id}")] HttpRequest req,
            string id,
            ILogger log)
        {
            var getByIdResult = await _expenseService.GetByIdAsync(id).ConfigureAwait(false);
            if (getByIdResult != null)
                return new OkObjectResult(getByIdResult);
            else
                return new BadRequestObjectResult(new { error = "Invalid request!" });
        }
    }
}
