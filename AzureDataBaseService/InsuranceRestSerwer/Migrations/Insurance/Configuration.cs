namespace InsuranceRestSerwer.Migrations.Insurance
{
    using InsuranceRestSerwer.Data;
    using InsuranceRestSerwer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InsuranceRestSerwer.Data.InsuranceContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Insurance";
        }

        protected override void Seed(InsuranceRestSerwer.Data.InsuranceContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // context.Clients.Add(TestData.getClient());

            //var realEstateInsurance = new RealEstateInsurance
            //{
            //    NumberOfFloors = 5,
            //    HasBasement = true,
            //    Adress = "Test",
            //    InsurancesId = 4,
            //    ConstructionDate = new DateTime(2017, 1, 18),
            //    StartDate = new DateTime(2017, 1, 18),
            //    FinishDate = new DateTime(2017, 1, 18),
            //    Insurances = context.Insurances.Find(20),
            
            //};
            //context.RealEstateInsurance.Add(realEstateInsurance);
             context.ClientDatas.Add(TestData.getClientData());
            // context.Insurances.Add(TestData.getInsurances());
            //context.RealEstateInsurance.Add(TestData.getRealEstateInsurance(context));
            context.SaveChanges();
        }
    }
}
