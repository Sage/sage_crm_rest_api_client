using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Api.Models
{
    public class LinkedType
    {
        [JsonPropertyName("Reference")]
        public IDictionary<string,object> Reference { get; set; }

        //public string Uri { get; set; }
        [JsonPropertyName("Association")]
        public IDictionary<string,object> Association { get; set; }
    }
}
