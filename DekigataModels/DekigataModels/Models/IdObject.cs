using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataModels.Models
{
    public abstract class IdObject
    {
        [JsonProperty("id")]
        public string Id { get; set; } = null!;
    }
}
