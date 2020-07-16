using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Sage.CRM.Rest.Api.Interface
{
    public static class EntityConverter
    {
        static JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, };
        public static string ToJson(object data)
        {
            return JsonSerializer.Serialize(data, defaultJsonSerializerOptions);
        }
        public static TValue ToEntity<TValue>(string data)
        {
            return JsonSerializer.Deserialize<TValue>(data,defaultJsonSerializerOptions);
        }
    }
}
