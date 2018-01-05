namespace InsuranceRestSerwer.Migrations.Insurance
{
    using InsuranceRestSerwer.Data;
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

             context.Clients.Add(TestData.getClient());
            // context.ClientDatas.Add(TestData.getClientData());
            // context.Insurances.Add(TestData.getInsurances());
            //context.RealEstateInsurance.Add(TestData.getRealEstateInsurance(context));
            context.SaveChanges();
        }
    }
}
