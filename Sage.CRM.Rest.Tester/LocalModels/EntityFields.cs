using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Tester.LocalModels
{
    public class EntityFields
    {
        [JsonPropertyName("$title")]
        public string Title { get; set; }
    }
}
