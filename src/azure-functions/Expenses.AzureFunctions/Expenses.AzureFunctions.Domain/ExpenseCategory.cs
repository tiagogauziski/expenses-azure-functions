using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Expenses.AzureFunctions.Domain
{
    public class ExpenseCategory
    {
        [JsonProperty("tenant")]
        public Guid TenantId { get; set; } = new Guid("965b2425-16c9-4595-a1c7-71e7c5cfbc6b");

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
