using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Expenses.AzureFunctions.Domain.Models
{
    public class Expense
    {
        [JsonProperty("tenant")]
        public Guid TenantId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}
