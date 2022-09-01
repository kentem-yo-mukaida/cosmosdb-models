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
    public static class AddDataHelper
    {
        public static async Task ExecuteAsync(DekigataCosmosDbContext context, SampleData sampleData)
        {
            // 工種
            var koshuContainer = await context.GetKoshuContainerAsync();
            foreach (var entity in sampleData.Koshus)
                await koshuContainer.CreateItemAsync(entity);

            // 測定項目
            var measurementItemContainer = await context.GetMeasurementItemAsync();
            foreach (var entity in sampleData.MeasurementItems)
                await measurementItemContainer.CreateItemAsync(entity);

            // 測点
            var measurementPointContainer = await context.GetMeasurementPointtContainerAsync();
            foreach (var entity in sampleData.MeasurementPoints)
                await measurementPointContainer.CreateItemAsync(entity);

            // 実測値
            var measurementValueContainer = await context.GetMeasurementValueContainerAsync();
            foreach (var entity in sampleData.MeasurementValues)
                await measurementValueContainer.CreateItemAsync(entity);
        }
    }
}
