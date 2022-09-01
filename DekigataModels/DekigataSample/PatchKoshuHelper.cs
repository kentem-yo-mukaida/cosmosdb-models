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
    public static class PatchKoshuHelper
    {
        public static async Task ExecuteAsync(DekigataCosmosDbContext context, string kojiId, string koshuId, string? newValue)
        {
            // 工種
            var koshuContainer = await context.GetKoshuContainerAsync();
            await koshuContainer.PatchItemAsync<KoshuEntity>(koshuId, new PartitionKey(kojiId), new List<PatchOperation>()
            {
                PatchOperation.Set("/sketchFile", newValue),
            });
        }
    }
}
