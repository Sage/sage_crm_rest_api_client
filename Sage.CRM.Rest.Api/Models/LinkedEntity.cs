using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Api.Models
{
    public class LinkedEntity
    {
        [JsonExtensionData]
        public IDictionary<string,object> Reference { get; set; }
    }
}
