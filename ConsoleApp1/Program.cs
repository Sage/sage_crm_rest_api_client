using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Sage.CRM.Rest.Api.Implementation;
using Sage.CRM.Rest.Api.Interface;
using System.Web.Helpers;

namespace ConsoleApp1
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }
        static async Task Run()
        {
            SageCRMRestClient client = new SageCRMBuilder()
                                            .SetBaseUrl("http://99.80.0.12/sdata/crm2020j/sagecrm2/-/")
                                            .SetLoginCredentials("admin", "")
                                            .Build();

            //var val = await client.GetAllEntities();
            //val.Resources.ForEach(i => Console.WriteLine($"{i.Entity}"));

            dynamic second = await client.GetEntityFieldsTest("company");
            //second.Fields(i => Console.WriteLine($"{i.Title}"));
            dynamic test = Json.Decode(second.ToString());


            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes($"admin:")));
            //HttpResponseMessage responseMessage = await httpClient.GetAsync("http://99.80.0.12/sdata/crm2020j/sagecrm2/-/email");
            //responseMessage.EnsureSuccessStatusCode();
            //string reposeBody = await responseMessage.Content.ReadAsStringAsync();
            //Console.WriteLine(reposeBody);

            //Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
