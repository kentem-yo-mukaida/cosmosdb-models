using DekigataModels.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataModels
{
    public class DekigataCosmosDbContext
    {
        public static async Task<DekigataCosmosDbContext> CreateAsync(string endpointUri, string primaryKey)
        {
            var context = new DekigataCosmosDbContext();
            context.Client = new CosmosClient(endpointUri, primaryKey);
            var response = await context.Client.CreateDatabaseIfNotExistsAsync(DekigataConsts.DatabaseName);
            context.Database = response.Database;
            Console.WriteLine($"Success get database: {DekigataConsts.DatabaseName}({context.Database.Id})\n");
            return context;
        }

        public CosmosClient Client { get; private set; } = null!;
        public Database Database { get; private set; } = null!;

        public async Task<Container> GetKoshuContainerAsync()
            => await GetOrCreateContainer(Database, KoshuEntity.ContainerName, KoshuEntity.PartitionKeyPath);
        public async Task<Container> GetMeasurementItemAsync()
            => await GetOrCreateContainer(Database, MeasurementItemEntity.ContainerName, MeasurementItemEntity.PartitionKeyPath);
        public async Task<Container> GetMeasurementValueContainerAsync()
            => await GetOrCreateContainer(Database, MeasurementValueEntity.ContainerName, MeasurementValueEntity.PartitionKeyPath);
        public async Task<Container> GetMeasurementPointtContainerAsync()
            => await GetOrCreateContainer(Database, MeasurementPointEntity.ContainerName, MeasurementPointEntity.PartitionKeyPath);

        private static async Task<Container> GetOrCreateContainer(Database database, string name, string partitionKeyPath)
        {
            var response = await database.CreateContainerIfNotExistsAsync(name, partitionKeyPath);
            var container = response.Container;
            Console.WriteLine($"Create container: {name}({container.Id})\n");
            return container;
        }
    }
}
