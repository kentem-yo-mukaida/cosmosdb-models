using DekigataModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataModels.Entities
{
    public class MeasurementValueEntity : IdObject
    {
        public const string ContainerName = "MeasurementValues";
        public const string PartitionKeyPath = "/koshu/id";

        /// <summary>工種</summary>
        [JsonProperty("koshu")]
        public KoshuObject Koshu { get; set; } = null!;

        /// <summary>測定項目</summary>
        [JsonProperty("measurementItem")]
        public MeasurementItemObject MeasurementItem { get; set; } = null!;

        /// <summary>測点</summary>
        [JsonProperty("point")]
        public MeasurementPointObject Point { get; set; } = null!;

        /// <summary>規格値</summary>
        [JsonProperty("ruleValue")]
        public ToleranceObject? RuleValue { get; set; }

        /// <summary>社内規格値</summary>
        [JsonProperty("inCompanyRuleValue")]
        public ToleranceObject? InCompanyRuleValue { get; set; }

        /// <summary>基準値</summary>
        [JsonProperty("standardValue")]
        public ToleranceObject? StandardValue { get; set; }

        /// <summary>設計値</summary>
        [JsonProperty("designValue")]
        public double? DesignValue { get; set; }

        /// <summary>実測</summary>
        [JsonProperty("values")]
        public MeasurementValueObject[]? Values { get; set; }

        public class KoshuObject : IdNameObject
        {
            /// <summary>種別名</summary>
            [JsonProperty("shubetu")]
            public string? Shubetu { get; set; }

            /// <summary>略図</summary>
            [JsonProperty("sketchFile")]
            public string? SketchFile { get; set; }
        }

        public class MeasurementItemObject : IdNameObject
        {
            /// <summary>記号</summary>
            [JsonProperty("mark")]
            public string? Mark { get; set; }

            /// <summary>単位</summary>
            [JsonProperty("unit")]
            public string? Unit { get; set; }

            /// <summary>桁</summary>
            [JsonProperty("degit")]
            public int Degit { get; set; }

            /// <summary>差の単位</summary>
            [JsonProperty("unitOfDifference")]
            public string? UnitOfDifference { get; set; }

            /// <summary>差の桁</summary>
            [JsonProperty("degitOfDifference")]
            public int DegitOfDifference { get; set; }
        }

        public class ToleranceObject
        {
            [JsonProperty("displayText")]
            public string? DisplayText { get; set; }

            [JsonProperty("upperLimit")]
            public double? UpperLimit { get; set; }

            [JsonProperty("lowerLimit")]
            public double? LowerLimit { get; set; }
        }

        public class MeasurementPointObject : IdNameObject
        {
            [JsonProperty("index")]
            public int Index { get; set; }
        }

        public class MeasurementValueObject
        {
            /// <summary>実測値</summary>
            [JsonProperty("actual")]
            public double? Actual { get; set; }

            /// <summary>差</summary>
            [JsonProperty("difference")]
            public double? Difference { get; set; }

            /// <summary>測定日</summary>
            [JsonProperty("date")]
            public DateTime? Date { get; set; }
        }
    }
}
