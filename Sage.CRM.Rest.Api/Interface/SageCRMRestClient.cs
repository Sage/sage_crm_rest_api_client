using Sage.CRM.Rest.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sage.CRM.Rest.Api.Interface
{
    public interface SageCRMRestClient
    {
        Task<T> Get<T>(string entityName, int? id);
        Task<MultipleRecord> Get(string entityName);
        Task<SingleRecord> Get(string entityName, int id);
        Task<Prototypes> GetAllEntities();
        Task<T> GetAllEntities<T>();
        Task<EntityFields> GetEntityFields(string entityName);
        Task<T> GetEntityFields<T>(string entityName);

        Task Add<T>(T entity, string entityName = null);
        Task Delete<T>(int id, string entityName = null);
        Task Delete(Expression expression);
        Task Edit<T>(int id, T entity, string entityName = null);
    }
}
