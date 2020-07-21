using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Tester.LocalModels
{
    public class Company
    {
        [JsonPropertyName("$key")]
        public int Id { get; set; }
        [JsonPropertyName("$totalResults")]
        public int ResultsAmount { get; set; }
        [JsonPropertyName("$title")]
        public string Title { get; set; }
        public int Comp_CompanyID { get; set; }
        public string Comp_Name { get; set; }

    }
}
