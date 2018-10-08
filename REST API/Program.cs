using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
class Program
{
    public class Datum
    {
        public int Id { get; set; }
        public string First_Num { get; set; }
        public string Last_Num { get; set; }
        public string Avatar { get; set; }
    }

    public class RootObject
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<Datum> Data { get; set; }
    }
    private const string URL = "https://reqres.in/api/";
    private static string urlParameters = "users?page=2";
    static void Main(String[] args)
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(URL);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = client.GetAsync(urlParameters).Result;
        if (response.IsSuccessStatusCode)
        {
            var data = response.Content.ReadAsStringAsync().Result;
            var businessunits = JsonConvert.DeserializeObject<RootObject>(data);
            Console.WriteLine(businessunits);
        }
        else
        {
            Console.WriteLine("hello");
        }
    }
}