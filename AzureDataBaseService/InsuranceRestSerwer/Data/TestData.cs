using InsuranceRestSerwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceRestSerwer.Data
{
    public class TestData
    {
        public static Client getClient()
        {
            var dataClient = new ClientData();
            dataClient.BirthDate = new DateTime(2017, 1, 18);
            dataClient.PeselNumber = 92081992;

            var isurances = new Insurances();

            List<RealEstateInsurance> realEstateInsurancesList = new List<RealEstateInsurance>
            {
                new RealEstateInsurance
                {
                    NumberOfFloors=4,
                    HasBasement=true,
                    Adress="TestAdress"
                },
                new RealEstateInsurance
                {
                    NumberOfFloors=5,
                    HasBasement=false,
                    Adress="TestAdress2"
                }
            };

            isurances.RealEstateInsurance = realEstateInsurancesList;

            var testClient = new Client();
            testClient.FirstName = "TestName";
            testClient.SecondName = "TestSecondName";
            testClient.ClientData = dataClient;
            testClient.Insurances = isurances;

            return testClient;
        }
    }


}