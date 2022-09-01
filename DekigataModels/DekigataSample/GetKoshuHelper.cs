using DekigataModels;
using DekigataModels.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataSample
{
    public static class GetKoshuHelper
    {
        public static async Task<KoshuEntity[]> ExecuteAsync(DekigataCosmosDbContext context, string kojiId, string koshuId)
        {
            var koshuContainer = await context.GetKoshuContainerAsync();
            var queryText = $"SELECT * FROM c WHERE c.id = '{koshuId}'";
            return (await GetAsync<KoshuEntity>(koshuContainer, kojiId, queryText)).ToArray();
        }

        public static async Task<IEnumerable<TEntity>> GetAsync<TEntity>(Container container, string? partitionKey, string? queryText = null)
        {
            var options = new QueryRequestOptions { MaxItemCount = 1000 };
            if (!string.IsNullOrEmpty(partitionKey))
                options.PartitionKey = new PartitionKey(partitionKey);
            var queryIterator = container.GetItemQueryIterator<TEntity>(queryText, requestOptions: options);

            return await GetAsync(queryIterator);
        }

        private static async Task<IEnumerable<TEntity>> GetAsync<TEntity>(FeedIterator<TEntity> queryIterator)
        {
            var result = new List<TEntity>();
            do
            {
                var stopwatch = Stopwatch.StartNew();
                try
                {
                    var response = await queryIterator.ReadNextAsync();
                    result.AddRange(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Faild load. {ex.Message}");
                    return new TEntity[0];
                }
                stopwatch.Stop();
                Console.WriteLine($"Loading time is {stopwatch.ElapsedMilliseconds}ms.");

            } while (queryIterator.HasMoreResults);

            return result;
        }
    }
}
