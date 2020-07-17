using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;
using Sage.CRM.Rest.Api.Models;

namespace Sage.CRM.Rest.Api.Helpers
{
    public class HttpService: IHttpService
    {
        private readonly HttpClient httpClient;
        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { 
                PropertyNameCaseInsensitive = true, 
                IgnoreNullValues = true, 
                AllowTrailingCommas = true };
        public HttpService()
        {
            httpClient = new HttpClient();   
        }
        public HttpService SetHeaderCredentials(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"{userName}:{password}")));
            //else
            //use session id here

            return this;
        }
        public HttpService SetSessionId(string sessionId)
        {
            return this;
        }
        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            var responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHTTP, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<T>(response, true, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default, false, responseHTTP);
            }
        }
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            string dataJson = "";
            if (typeof(T).Name != "String")
                dataJson = JsonSerializer.Serialize(data);
            else
                dataJson = data.ToString();
            
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var responseHTTP = await httpClient.PostAsync(url, stringContent);
            var response = await Deserialize<object>(responseHTTP, defaultJsonSerializerOptions);
            return new HttpResponseWrapper<object>(response, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data, defaultJsonSerializerOptions);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);
            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, false, response);
            }
        }
        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var responseHTTP = await httpClient.DeleteAsync(url);
            return new HttpResponseWrapper<object>(null, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
