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
            Run().GetAwaiter().GetResult();
            //TestConverter();
        }
        static async Task Run()
        {
            SageCRMRestClient client = new SageCRMBuilder()
                                            .SetBaseUrl("http://99.80.0.12/sdata/crm2020j/sagecrm2/-/")
                                            .SetLoginCredentials("admin","")
                                            .Build();

            //all tests
            //returns Prototypes
            var proto = await client.GetAllEntities();
            //returns myClass
            ProtosClass protosClass = await client.GetAllEntities<ProtosClass>();
            
            
            //get entity fields
            var entities = await client.GetEntityFields("company");
            //get entity fields with custom class
            EntityFields entityFields = await client.GetEntityFields<EntityFields>("company");
            
            
            //get ALL from company with ResultPayload
            var resultPayload = await client.Get("company");
            //get ALL from company with Custom Class
            Company a = await client.Get<Company>("company", null);


            //get ALL from company with ResultPayload
            var resultPayload2 = await client.Get("company", 1222);
            //get ALL from company with Custom Class
            Company ab = await client.Get<Company>("company", 1222);


            Console.ReadLine();
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
