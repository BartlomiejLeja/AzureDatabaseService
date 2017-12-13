# AzureDatabaseService
WCF service that will manage CRUD operations

****************************************************** Instruction ***********************************************************************

1)Simple rest GET in .NET using restSharp

var restClient = new RestClient("http://insurancerestserwer20171130090720.azurewebsites.net"); //serwer url always the same
IRestResponse response = restClient.Execute(new RestRequest("/api/Clients/1", Method.GET)); /rest method route (get client with Id 1)
 
2)Simple deserializable into client class
 
var client = JsonConvert.DeserializeObject<Client>(response.Content);
  




