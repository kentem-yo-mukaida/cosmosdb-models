using DekigataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataModels.Entities
{
    public class MeasurementItemEntity : IdNameObject
    {
        public const string ContainerName = "MeasurementItems";
        public const string PartitionKeyPath = "/koshu/id";

        [JsonProperty("koshu")]
        public KoshuObject Koshu { get; set; } = null!;

        [JsonProperty("mark")]
        public string? Mark { get; set; }

        [JsonProperty("unit")]
        public string? Unit { get; set; }

        [JsonProperty("degit")]
        public int Degit { get; set; }

        [JsonProperty("unitOfDifference")]
        public string? UnitOfDifference { get; set; }

        [JsonProperty("degitOfDifference")]
        public int DegitOfDifference { get; set; }

        public class KoshuObject : IdNameObject
        {
            [JsonProperty("shubetu")]
            public string? Shubetu { get; set; }

            [JsonProperty("sketchFile")]
            public string? SketchFile { get; set; }
        }
    }
}
