using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Expenses.AzureFunctions.Domain.Models
{
    public class Expense
    {
        [JsonProperty("tenant")]
        public Guid TenantId { get; set; } = new Guid("965b2425-16c9-4595-a1c7-71e7c5cfbc6b");

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
