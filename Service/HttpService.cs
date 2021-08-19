using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace api_covid.Service
{
    public static class HttpService<T>
    {
        private static string _urlbase=> "https://api.covid19api.com/";
        
        public static T Request(string service)
        {
            var client = new RestClient($"{_urlbase}{service}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return JsonSerializer.Deserialize<T>(response.Content);
        }

    }
}