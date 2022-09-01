using System;
using System.Collections.Generic;
using DekigataModels.Entities;
using DekigataModels;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using System.Configuration.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PartitionKey = Microsoft.Azure.Cosmos.PartitionKey;
using System.Diagnostics;
using System.Linq;

namespace DekigataChangeFeed
{
    public static class KoshuChanged
    {
        private const string ConnectionStringSettingPath = "CosmosDb:ConnectionString";

        [FunctionName("KoshuChanged")]
        public static async Task Run(
            ExecutionContext context,
            [CosmosDBTrigger(
            databaseName: DekigataConsts.DatabaseName,
            collectionName: KoshuEntity.ContainerName,
            ConnectionStringSetting = ConnectionStringSettingPath,
            LeaseCollectionName = "leases",
            CreateLeaseCollectionIfNotExists = true
            )]IReadOnlyList<Microsoft.Azure.Documents.Document> input,
            ILogger log)
        {
            if (input is null || input.Count == 0)
                return;

            var connectionString = context.GetConfiguration()[ConnectionStringSettingPath];
            var client = new CosmosClient(connectionString);
            var database = client.GetDatabase(DekigataConsts.DatabaseName);
            var inputJsons = input.Select(q => q.ToString()).ToArray();

            // 工種を参照しているデータを更新
            await PatchMeasurementItemAsync(database, inputJsons);
            //await PatchMeasurementPointAsync(database, inputJsons);
            //await PatchMeasurementValueAsync(database, inputJsons);
        }

        private static async Task PatchMeasurementItemAsync(Database database, string[] inputJsons)
        {
            var container = database.GetContainer(MeasurementItemEntity.ContainerName);
            foreach (var json in inputJsons)
                await PatchMeasurementItemAsync(container, json);
        }
        private static async Task PatchMeasurementItemAsync(Container container, string inputJson)
        {
            var koshu = JsonConvert.DeserializeObject<MeasurementItemEntity.KoshuObject>(inputJson);
            var partitionKey = new PartitionKey(koshu.Id);
            var measurementItems = await GetItemsAsync<MeasurementItemEntity>(container, partitionKey);

            var batch = container.CreateTransactionalBatch(partitionKey);
            foreach (var item in measurementItems)
            {
                item.Koshu = koshu;
                batch.UpsertItem(item);
            }

            var response = await batch.ExecuteAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed patch masurement item.");
        }

        private static async Task<IEnumerable<TEntity>> GetItemsAsync<TEntity>(Container container, PartitionKey partitionKey)
        {
            var options = new QueryRequestOptions { PartitionKey = partitionKey, MaxItemCount = 1000 };
            var queryIterator = container.GetItemQueryIterator<TEntity>(requestOptions: options);

            var result = new List<TEntity>();
            do
            {
                result.AddRange(await queryIterator.ReadNextAsync());
            } while (queryIterator.HasMoreResults);

            return result;
        }
    }
}
