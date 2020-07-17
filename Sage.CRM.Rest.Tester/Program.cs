using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

using Sage.CRM.Rest.Api.Interface;
using Sage.CRM.Rest.Tester.LocalModels;

namespace Sage.CRM.Rest.Tester
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            SageCRMRestClient client = new SageCRMBuilder()
                                            .SetBaseUrl("http://192.168.125.142/sdata/crm2020j/sagecrm2/-/")
                                            .SetLoginCredentials("admin", "")
                                            .Build();

            //Gets(client).GetAwaiter().GetResult();
            //Posts(client).GetAwaiter().GetResult();
            Puts(client).GetAwaiter().GetResult();
            //Delete(client).GetAwaiter().GetResult();
            //TestConverter();
        }
        static async Task Gets(SageCRMRestClient client)
        {
            ////all tests
            ////returns Prototypes
            //var proto = await client.GetAllEntities();
            ////returns myClass
            //ProtosClass protosClass = await client.GetAllEntities<ProtosClass>();
            
            
            ////get entity fields
            //var entities = await client.GetEntityFields("company");
            ////get entity fields with custom class
            //EntityFields entityFields = await client.GetEntityFields<EntityFields>("company");
            
            
            ////get ALL from company with ResultPayload
            //var resultPayload = await client.Get("company");
            ////get ALL from company with Custom Class
            //Company a = await client.Get<Company>("company", null);


            //get ALL from company with ResultPayload
            var resultPayload2 = await client.Get("company", 1222);
            //get ALL from company with Custom Class
            Company ab = await client.Get<Company>("company", 1222);


            Console.ReadLine();
        }
        static async Task Posts(SageCRMRestClient client)
        {
            Company company = new Company();
            company.Comp_Name = "Conrad new 123";
            await client.Add(company);

            //string companyData = "{ \"comp_name\" : \"Conrads New Company Method\" }";
            //await client.Add("company",companyData);
        }
        static async Task Puts(SageCRMRestClient client)
        {
            CompanyPutModel put = new CompanyPutModel();
            //put.Comp_Name = "Conrad Put";
            put.Comp_Website = "http://www.conrad.com";

            await client.Edit(1231, put, "company");
        }
        static async Task Deletes(SageCRMRestClient client)
        {
            await client.Delete<Company>(1231);
        }
        static void TestConverter()
        {
            Car car = new Car();
            car.ID = 1;
            car.Name = "Ford";
            car.Something = "Something else";

            string a = EntityConverter.ToJson(car);
            Car newCar = EntityConverter.ToEntity<Car>(a);
        }
    }

    class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Something { get; set; }
    }
}
