using InsuranceApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System;

namespace InsuranceApp
{
    public class RestSharpHandler
    {
        const string hostName = "https://insurancerestserwer20180104090036.azurewebsites.net";
        RestClient restClient = new RestClient(hostName);
        public Client GetClient(int id)
        {
            IRestResponse response = restClient.Execute(new RestRequest($"/api/Clients/{id}", Method.GET));
            var clients = JsonConvert.DeserializeObject<Client>(response.Content);
            return clients;
        }



        public void CreateClient(string firstName, string secondName,DateTime? dayOfBirth, int peselNumber)
        {
            var dataClient = new ClientData
            {
                BirthDate = dayOfBirth,
                PeselNumber = peselNumber,
            };

            var isurances = new Insurances();

            var clientToAdd = new Client
            {
                FirstName = firstName,
                SecondName = secondName,
                ClientData = dataClient,
                Insurances = isurances,
            };

            var request = new RestRequest("api/Clients", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(clientToAdd);
            restClient.Execute(request);
        }

        public void CreateClient(string firstName, string secondName, DateTime? dayOfBirth, int peselNumber, int id)
        {
            var dataClient = new ClientData
            {
                BirthDate = dayOfBirth,
                PeselNumber = peselNumber,
            };

            var isurances = new Insurances();

            var clientToAdd = new Client
            {
                FirstName = firstName,
                SecondName = secondName,
                ClientData = dataClient,
                Insurances = isurances,
                ClientId = id,
            };

            var request = new RestRequest("api/Clients", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(clientToAdd);
            restClient.Execute(request);
        }

        public void RemoveClient(int id)
        {
            var clientDataDeleteRestRequest = new RestRequest($"api/ClientDatas/{id}", Method.DELETE);
            var discountDataDeleteRestRequest = new RestRequest($"api/Discounts/{id}", Method.DELETE);
            var realInsuranceDeleteRestRequest = new RestRequest($"api/Insurances/{id}", Method.DELETE);
            var insuranceDeleteRestRequest = new RestRequest($"api/RealEstateInsurances/{id}", Method.DELETE);
            var clientDeleteRequest = new RestRequest($"api/Clients/{id}", Method.DELETE);

            restClient.Execute(clientDataDeleteRestRequest);
            restClient.Execute(discountDataDeleteRestRequest);
            restClient.Execute(realInsuranceDeleteRestRequest);
            restClient.Execute(insuranceDeleteRestRequest);
            restClient.Execute(clientDeleteRequest);
        }

        public void ModifyClient(int id, Client clientToModify)
        {
            var request = new RestRequest($"api/Clients/{id}", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(clientToModify);
            restClient.Execute(request);
        }
        public void ModifyClient(int id)
        {

         //   var request = new RestRequest("api/Clients", Method.DELETE);
         //   restClient.Execute(request);
        }

        public List<Client> GetAllClientdata()
        {
            var restClient = new RestClient("http://insurancerestserwer20171130090720.azurewebsites.net");
            IRestResponse response = restClient.Execute(new RestRequest("/api/Clients/", Method.GET));


             var clients = JsonConvert.DeserializeObject<List<Client>>(response.Content);
            return clients;
        }

    }
}
