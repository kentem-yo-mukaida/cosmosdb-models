using DekigataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataModels.Entities
{
    public class MeasurementPointEntity : IdNameObject
    {
        public const string ContainerName = "MeasurementPoints";
        public const string PartitionKeyPath = "/koshu/id";

        [JsonProperty("koshu")]
        public KoshuObject Koshu { get; set; } = null!;

        [JsonProperty("index")]
        public int Index { get; set; }

        public class KoshuObject : IdNameObject
        {
        }
    }
}
