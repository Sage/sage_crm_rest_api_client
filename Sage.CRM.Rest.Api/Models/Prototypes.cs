using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Api.Models
{
    public class Prototypes
    {
        [JsonPropertyName("$totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("$resources")]
        public List<EntityFields> EntityList { get; set; }
    }
}
