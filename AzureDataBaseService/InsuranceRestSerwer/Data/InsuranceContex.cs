using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InsuranceRestSerwer.Models;

namespace InsuranceRestSerwer.Data
{
    public class InsuranceContex : DbContext
    {
       public InsuranceContex(): base("DefaultConnection")
        {}

        public DbSet<Insurances> Insurances { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientData> ClientDatas { get; set; }
        public DbSet<HealthInsurance> HealthInsurances { get; set; }


    }
}
