using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sage.CRM.Rest.Tester.LocalModels
{
    public class Company
    {
        [JsonPropertyName("$totalResults")]
        public int ResultsAmount { get; set; }
        [JsonPropertyName("$title")]
        public string Title { get; set; }
        public int Comp_CompanyID { get; set; }

    }
}
