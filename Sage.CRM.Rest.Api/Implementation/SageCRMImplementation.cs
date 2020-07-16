using Sage.CRM.Rest.Api.Helpers;
using Sage.CRM.Rest.Api.Interface;
using Sage.CRM.Rest.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sage.CRM.Rest.Api.Implementation
{
    public class SageCRMImplementation : SageCRMRestClient
    {
        IHttpService httpService;
        string _baseUrl = "";
        public SageCRMImplementation(string baseUrl, string userName, string password)
        {
            httpService = new HttpService();
            httpService.SetHeaderCredentials(userName, password);
            _baseUrl = baseUrl;
        }
        public Task Add<T>(T entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Expression expression)
        {
            throw new NotImplementedException();
        }
        public Task Edit<T>(int id, T entity)
        {
            throw new NotImplementedException();
        }


        #region Gets
        public async Task<T> Get<T>(string entityName, int? id)
        {
            if(id.HasValue)
                return await GetInternal<T>($"{entityName}('{id}')");
            else
                return await GetInternal<T>($"{entityName}");
        }
        public async Task<MultipleRecord> Get(string entityName)
        {
            return await GetInternal<MultipleRecord>($"{entityName}");
        }
        public async Task<SingleRecord> Get(string entityName, int id)
        {
            return await GetInternal<SingleRecord>($"{entityName}('{id}')");
        }
        public async Task<Prototypes> GetAllEntities()
        {
            return await GetInternal<Prototypes>($"$prototypes");
        }
        public async Task<T> GetAllEntities<T>()
        {
            return await GetInternal<T>($"$prototypes");
        }
        public async Task<EntityFields> GetEntityFields(string entityName)
        {
            return await GetInternal<EntityFields>($"$prototypes/{entityName}");
        }
        public async Task<T> GetEntityFields<T>(string entityName)
        {
            return await GetInternal<T>($"$prototypes/{entityName}");
        }
        #endregion

        #region PrivateGenerics
        private async Task<T> GetInternal<T>(string urlAppend)
        {
            var response = await httpService.Get<T>($"{_baseUrl}/{urlAppend}");
            if (!response.Success)
                throw new ApplicationException(await response.GetBody());
            return response.Response;
        }
        #endregion
    }
}
