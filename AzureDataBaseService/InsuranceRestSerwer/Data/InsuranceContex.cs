using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InsuranceRestSerwer.Models;
using InsuranceRestSerwer.Models.CarInsurances;
using InsuranceRestSerwer.Models.TravelInsurances;

namespace InsuranceRestSerwer.Data
{
    public class InsuranceContex : DbContext
    {
       public InsuranceContex(): base("Data Source=insuranceappdatabaseserver.database.windows.net;Initial Catalog=insuranceappdatabase;Persist Security Info=True;User ID=BartlomiejLeja;Password=Insurance!")
        {}

        public DbSet<Insurances> Insurances { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientData> ClientDatas { get; set; }
        public DbSet<CarInsurance> CarInsurance { get; set; }
        public DbSet<CarInsuranceApplication> CarInsuranceApplication { get; set; }
        public DbSet<RealEstateInsurance> RealEstateInsurance { get; set; }
        public DbSet<Offenders> Offenders { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<TypeOfCarInsurance> TypeOfCarInsurance { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<TravelInsurance> TravelInsurance { get; set; }
        public DbSet<AdditionalOptions> AdditionalOptions { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Discount> Discount { get; set; }

    }
}
