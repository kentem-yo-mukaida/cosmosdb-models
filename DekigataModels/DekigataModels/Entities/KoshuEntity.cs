using DekigataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataModels.Entities
{
    public class KoshuEntity : IdNameObject
    {
        public const string ContainerName = "Koshus";
        public const string PartitionKeyPath = "/koji/id";

        [JsonProperty("koji")]
        public KojiObject Koji { get; set; } = null!;

        [JsonProperty("shubetu")]
        public string? Shubetu { get; set; }

        [JsonProperty("saibetu")]
        public string? Saibetu { get; set; }

        [JsonProperty("sketchFile")]
        public string? SketchFile { get; set; }

        public class KojiObject : IdNameObject
        {
        }
    }
}
