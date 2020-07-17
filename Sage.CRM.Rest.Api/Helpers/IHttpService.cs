using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sage.CRM.Rest.Api.Helpers
{
    interface IHttpService
    {
        HttpService SetHeaderCredentials(string userName, string password);
        Task<HttpResponseWrapper<object>> Delete(string url);
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T data);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T data);
    }
}
