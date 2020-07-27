using Sage.CRM.Rest.Api.Interface;

using Sage.CRM.Rest.Api.Models;

using Sage.CRM.Rest.Tester.LocalModels;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sage.CRM.Rest.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            SageCRMRestClient client = new SageCRMBuilder()
                                            .SetBaseUrl("http://192.168.125.133/sdata/crm2020j/sagecrm2/-/")
                                            .SetLoginCredentials("admin", "")
                                            .Build();

            Gets(client).GetAwaiter().GetResult();
            //Posts(client).GetAwaiter().GetResult();
            //Puts(client).GetAwaiter().GetResult();
            //Delete(client).GetAwaiter().GetResult();
            //TestConverter();

            Console.ReadLine();
        }
        static async Task Gets(SageCRMRestClient client)
        {
            #region GetEntities
            //returns Prototypes with Protypes class
            //var proto = await client.GetAllEntities();
            //proto.EntityList.ForEach(entity => Console.WriteLine(entity.EntityName));
            #endregion

            #region CustomClass
            //returns myClass
            //ProtosClass protosClass = await client.GetAllEntities<ProtosClass>();
            //Console.WriteLine(protosClass.Title);
            #endregion

            #region EntityFields
            //get entity fields
            //var entities = await client.GetEntityFields("address");
            //foreach (KeyValuePair<string, Field> entries in entities.Fields)
            //{
            //    Console.WriteLine($"{entries.Key} : {entries.Value.Type}");
            //}
            #endregion

            #region CustomEntity
            //get entity fields with custom class
            //EntityField entityFields = await client.GetEntityFields<EntityField>("company");
            #endregion

            #region All Entity Fields
            //get ALL from company with ResultPayload
            var resultPayload = await client.Get("company");
            resultPayload.Records.ForEach(rec => Console.WriteLine($"{rec.RecordId} : {rec.Name}"));
            #endregion

            #region Entity Fields with custom 
            //get ALL from company with Custom Class
            Company a = await client.Get<Company>("company", null);
            #endregion

            #region Get Comp by ID
            //get ALL from company with ResultPayload
            var resultPayload2 = await client.Get("company", 1222);
            #endregion

            #region CustomClass by ID
            //get ALL from company with Custom Class
            Company ab = await client.Get<Company>("company", 1222);
            #endregion
        }
        static async Task Posts(SageCRMRestClient client)
        {
            Company company = new Company();
            company.Comp_Name = "Conrad new 123";
            var result = await client.Add(company, "company");

            //second example
            string companyData = "{ \"comp_name\" : \"Conrads New Company Method\" }";
            await client.Add(companyData,"company");
        }
        static async Task Puts(SageCRMRestClient client)
        {
            CompanyPutModel put = new CompanyPutModel();
            put.Comp_Website = "http://www.conrad.com";

            await client.Edit(1231, put, "company");
        }
        static async Task Deletes(SageCRMRestClient client)
        {
            await client.Delete<Company>(1231);
        }
        static void TestConverter()
        {
            Comp comp = new Comp();
            comp.Comp_Name = "testname";
            comp.Comp_Website = "Ford";

            string a = EntityConverter.ToJson(comp);
            Comp newComp = EntityConverter.ToEntity<Comp>(a);
        }
    }
}
