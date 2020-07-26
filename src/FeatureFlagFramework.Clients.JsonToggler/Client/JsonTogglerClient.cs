using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlagFramework.Clients.JsonToggler.Client
{
    public class JsonTogglerClient
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string url;

        public JsonTogglerClient(string url)
        {
            this.url = url;
        }

        internal bool BoolVariation(string flagName, bool defaultValue)
        {
            return false;
            //try
            //{
            //    HttpResponseMessage response = await client.GetAsync(url);
            //    response.EnsureSuccessStatusCode();
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    // Above three lines can be replaced with new helper method below
            //    // string responseBody = await client.GetStringAsync(uri);

            //    Console.WriteLine(responseBody);
            //}
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine("\nException Caught!");
            //    Console.WriteLine("Message :{0} ", e.Message);
            //}
        }



        async Task Request()
        {
            //using (var httpClient = new HttpClient())
            //{
            //    httpClient. = new Uri(this.url);
            //    httpClient.DefaultRequestHeaders.Accept.Clear();
            //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    var response = await httpClient.GetAsync("api/session");
            //    if (response.StatusCode != HttpStatusCode.OK)
            //        return null;
            //    var resourceJson = await response.Content.ReadAsStringAsync();
            //    return JsonUtility.FromJson<Resource>(resourceJson);
            //}


            //// Call asynchronous network methods in a try/catch block to handle exceptions.
            //try
            //{
            //    HttpResponseMessage response = await client.GetAsync(this.url);
            //    response.EnsureSuccessStatusCode();
            //    string responseBody = await response.Content.ReadAsStringAsync();
            //    // Above three lines can be replaced with new helper method below
            //    // string responseBody = await client.GetStringAsync(uri);

            //    Console.WriteLine(responseBody);
            //}
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine("\nException Caught!");
            //    Console.WriteLine("Message :{0} ", e.Message);
            //}
        }
    }
}
