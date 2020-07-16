using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Api.Models
{
    public class SingleRecord
    {
        [JsonPropertyName("$key")]
        public int RecordId { get; set; }
        [JsonPropertyName("$title")]
        public string Name { get; set; }
        [JsonPropertyName("$url")]
        public string Url { get; set; }
        [JsonExtensionData]
        public IDictionary<string, object> Fields { get; set; }
        [JsonPropertyName("Person")]
        public LinkedEntity PersonLinkedEntity { get; set; }
        [JsonPropertyName("Company")]
        public LinkedEntity CompanyLinkedEntity { get; set; }
        [JsonPropertyName("Address")]
        public LinkedEntity AddressLinkedEntity { get; set; }
        [JsonPropertyName("Account")]
        public LinkedEntity AccountLinkedEntity { get; set; }
        [JsonPropertyName("Opportunity")]
        public LinkedEntity OpportunityLinkedEntity { get; set; }
        [JsonPropertyName("Cases")]
        public LinkedEntity CasesLinkedEntity { get; set; }
        [JsonPropertyName("Communication")]
        public LinkedEntity CommunicationLinkedEntity { get; set; }
        [JsonPropertyName("Library")]
        public LinkedEntity LibraryLinkedEntity { get; set; }
        [JsonPropertyName("Users")]
        public LinkedEntity UsersLinkedEntity { get; set; }
    }
}
