using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Api.Models
{
    public class EntityFields
    {
        [JsonPropertyName("$title")]
        public string Title { get; set; } 
        [JsonPropertyName("$baseUrl")]
        public string BaseUrl { get; set; }
        [JsonPropertyName("$url")]
        public string Url { get; set; }
        [JsonPropertyName("$resourceId")]
        public int EntityId { get; set; }
        [JsonPropertyName("$properties")]
        public IDictionary<string,Field> Fields { get; set; }
        [JsonPropertyName("$resourceKind")]
        public string EntityName { get; set; }
    }
}
