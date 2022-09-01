using DekigataModels;
using DekigataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataSample
{
    public static class UpdateKoshuHelper
    {
        public static async Task ExecuteAsync(DekigataCosmosDbContext context, string kojiId, string koshuId, string? newValue)
        {
            // 工種
            var koshu = (await GetKoshuHelper.ExecuteAsync(context, kojiId, koshuId)).FirstOrDefault();
            if (koshu is null)
                throw new Exception("Koshu not found.");

            Console.WriteLine($"Change {nameof(koshu.SketchFile)}, '{koshu.SketchFile}' to '{newValue}'.");

            koshu.SketchFile = newValue;
            var koshuContainer = await context.GetKoshuContainerAsync();
            await koshuContainer.UpsertItemAsync(koshu);
        }
    }
}
