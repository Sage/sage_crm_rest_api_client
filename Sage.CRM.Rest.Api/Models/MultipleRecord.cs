using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Api.Models
{
    public class MultipleRecord
    {
        //top level Entities
        [JsonPropertyName("$totalResults")]
        public int TotalResults { get; set; }
        [JsonPropertyName("$startIndex")]
        public int StartIndex { get; set; }
        [JsonPropertyName("$itemsPerPage")]
        public int ItemsPerPage { get; set; }
        [JsonPropertyName("$resources")]
        public List<SingleRecord> Records { get; set; }
    }
}
