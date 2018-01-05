using InsuranceRestSerwer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceRestSerwer.Data
{
    public class TestData
    {
        public static Client getClient1()
        {
            //var dataClient = new ClientData();
            //dataClient.BirthDate = new DateTime(2017, 1, 18);
            //dataClient.PeselNumber = 92081992;

            var isurances = new Insurances();

            //List<RealEstateInsurance> realEstateInsurancesList = new List<RealEstateInsurance>
            //{
            //    new RealEstateInsurance
            //    {
            //        NumberOfFloors=4,
            //        HasBasement=true,
            //        Adress="TestAdress"
            //    },
            //    new RealEstateInsurance
            //    {
            //        NumberOfFloors=5,
            //        HasBasement=false,
            //        Adress="TestAdress2"
            //    }
            //};

           // isurances.RealEstateInsurance = realEstateInsurancesList;

            var testClient = new Client();
            testClient.FirstName = "TestName1";
            testClient.SecondName = "TestSecondName1";
           // testClient.ClientData = dataClient;
            testClient.Insurances = isurances;

            return testClient;
        }

        public static List<RealEstateInsurance> getRealEstateInsurance()
        {
            List<RealEstateInsurance> realEstateInsurancesList = new List<RealEstateInsurance>
            {
                 new RealEstateInsurance
                {
            NumberOfFloors = 5,
            HasBasement = true,
            Adress = "TestAdress1",
           Insurance = 4,
            ConstructionDate = new DateTime(2017, 1, 18),
            StartDate = new DateTime(2017, 1, 18),
            FinishDate = new DateTime(2017, 1, 18),
               },
           
                new RealEstateInsurance
               {
                   NumberOfFloors=5,
                    HasBasement=false,
                   Adress="TestAdress2",
                   ConstructionDate = new DateTime(2016, 1, 18),
            StartDate = new DateTime(2016, 1, 18),
            FinishDate = new DateTime(2016, 1, 18),
               }
            };
            return realEstateInsurancesList;
        }

        public static ClientData getClientData()
        {
            var dataClient = new ClientData();
            dataClient.BirthDate = new DateTime(2017, 1, 18);
            dataClient.PeselNumber = 920819927;
            return dataClient;
        }

        public static Client getClient()
        {
            var client = new Client();
            client.FirstName = "TestName2";
            client.SecondName = "TestSecondName2";
            client.ClientData = getClientData();
            client.Insurances = getInsurances();
            return client;
        }

        public static Insurances getInsurances()
        {
            var isurances = new Insurances();
            isurances.RealEstateInsurance = getRealEstateInsurance();
           
            return isurances;
        }

    }
}