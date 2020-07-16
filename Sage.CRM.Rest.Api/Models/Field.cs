using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Api.Models
{
    public class Field
    {
        [JsonPropertyName("$title")]
        public string Title { get; set; }

        [JsonPropertyName("$type")]
        public string Type { get; set; }
        
        [JsonPropertyName("$isMandatory")]
        public bool IsMandatory { get; set; }

        [JsonPropertyName("$isHidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("$isReadOnly")]
        public bool IsReadOnly { get; set; }
    }
}
