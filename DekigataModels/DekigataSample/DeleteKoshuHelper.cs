using DekigataModels;
using DekigataModels.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataSample
{
    public static class DeleteKoshuHelper
    {
        public static async Task ExecuteAsync(DekigataCosmosDbContext context, string kojiId, string koshuId)
        {
            // 工種
            var koshuContainer = await context.GetKoshuContainerAsync();
            await koshuContainer.DeleteItemAsync<KoshuEntity>(koshuId, new PartitionKey(kojiId));
        }
    }
}
