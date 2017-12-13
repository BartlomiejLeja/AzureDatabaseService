using InsuranceApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace InsuranceApp
{
    class RestSharpHandler
    {
        public string GetClientdata()
        {
            var restClient = new RestClient("http://insurancerestserwer20171130090720.azurewebsites.net");
            IRestResponse response = restClient.Execute(new RestRequest("/api/Clients/1", Method.GET));
            var client = JsonConvert.DeserializeObject<Client>(response.Content);
            return client.FirstName;
        }
    }
}
