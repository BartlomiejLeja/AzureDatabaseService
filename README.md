# AzureDatabaseService
WCF service that will manage CRUD operations

********************** Instruction *****************************

1)Simple rest GET in .NET using restSharp

var restClient = new RestClient("https://insurancerestserwer20180104090036.azurewebsites.net"); //serwer url always the same
IRestResponse response = restClient.Execute(new RestRequest("/api/Clients/1", Method.GET)); (get client with Id 1)

2)All ORM mapped classe are in https://github.com/BartlomiejLeja/AzureDatabaseService/tree/master/AzureDataBaseService/InsuranceRestSerwer/Models
Use it to create your own model and send it using rest server.

3)All rest methods are in https://github.com/BartlomiejLeja/AzureDatabaseService/tree/master/AzureDataBaseService/InsuranceRestSerwer/Controllers
 
4)Simple deserializable into client class
 
var client = JsonConvert.DeserializeObject<Client>(response.Content);
  




