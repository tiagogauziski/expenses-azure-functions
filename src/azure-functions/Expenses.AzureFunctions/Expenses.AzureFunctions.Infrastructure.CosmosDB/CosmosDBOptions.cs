using System;
using System.Collections.Generic;
using System.Text;

namespace Expenses.AzureFunctions.Infrastructure.CosmosDB
{
    public class CosmosDBOptions
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
