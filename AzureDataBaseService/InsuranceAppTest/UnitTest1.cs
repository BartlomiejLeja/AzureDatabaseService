using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsuranceApp;
using InsuranceApp.Models;

namespace InsuranceAppTest
{
    [TestClass]
    public class RestSharpHandlerTest
    {
        RestSharpHandler RestSarpHandler = new RestSharpHandler();

        [TestMethod]
        public void CreateClient()
        {
            var firstName = "Magda";
            RestSarpHandler.CreateClient(firstName, "Migas", DateTime.Now, 93,200);

            var client = RestSarpHandler.GetClientdata(200);

            Assert.AreEqual(firstName, client.FirstName);
        }


        [TestMethod]
        public void DeleteClient()
        {
            RestSarpHandler.RemoveClient(200);

            var client = RestSarpHandler.GetClientdata(200);

            Assert.AreEqual(client, null);
        }

        [TestMethod]
        public void ModifyClient()
        {
            var testClient = new Client()
            {
                FirstName="Bartek",
                SecondName="Leja"
            };
            RestSarpHandler.ModifyClient(200, testClient);

            var client = RestSarpHandler.GetClientdata(200);

            Assert.AreEqual("Bartek", client.FirstName);
        }

    }
}
