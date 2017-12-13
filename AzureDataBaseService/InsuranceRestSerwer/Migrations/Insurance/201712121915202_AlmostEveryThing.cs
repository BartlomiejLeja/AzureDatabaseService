namespace InsuranceRestSerwer.Migrations.Insurance
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlmostEveryThing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false),
                        ValueOfDiscount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountId)
                .ForeignKey("dbo.Clients", t => t.DiscountId)
                .Index(t => t.DiscountId);
            
            CreateTable(
                "dbo.CarInsurances",
                c => new
                    {
                        CarInsuranceId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        Insurance = c.Int(nullable: false),
                        Insurances_InsurancesId = c.Int(),
                    })
                .PrimaryKey(t => t.CarInsuranceId)
                .ForeignKey("dbo.Insurances", t => t.Insurances_InsurancesId)
                .Index(t => t.Insurances_InsurancesId);
            
            CreateTable(
                "dbo.CarInsuranceApplications",
                c => new
                    {
                        CarInsuranceApplicationId = c.Int(nullable: false, identity: true),
                        Statsu = c.String(),
                        Date = c.DateTime(nullable: false),
                        AccidentPlace = c.String(),
                        CarInsurance_CarInsuranceId = c.Int(),
                    })
                .PrimaryKey(t => t.CarInsuranceApplicationId)
                .ForeignKey("dbo.CarInsurances", t => t.CarInsurance_CarInsuranceId)
                .Index(t => t.CarInsurance_CarInsuranceId);
            
            CreateTable(
                "dbo.Offenders",
                c => new
                    {
                        OffendersId = c.Int(nullable: false),
                        PeselNumber = c.Int(nullable: false),
                        Adress = c.String(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.OffendersId)
                .ForeignKey("dbo.CarInsuranceApplications", t => t.OffendersId)
                .Index(t => t.OffendersId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.CarInsurances", t => t.PaymentId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.TypeOfCarInsurances",
                c => new
                    {
                        TypeOfCarInsuranceId = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TypeOfCarInsuranceId)
                .ForeignKey("dbo.CarInsurances", t => t.TypeOfCarInsuranceId)
                .Index(t => t.TypeOfCarInsuranceId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false),
                        EngineCapacity = c.Double(nullable: false),
                        ProductionYear = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.CarInsurances", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.RealEstateInsurances",
                c => new
                    {
                        RealEstateInsuranceId = c.Int(nullable: false, identity: true),
                        MetricArea = c.Double(nullable: false),
                        NumberOfFloors = c.Int(nullable: false),
                        ConstructionDate = c.DateTime(nullable: false),
                        NumberOfGarages = c.Int(nullable: false),
                        HasBasement = c.Boolean(nullable: false),
                        Adress = c.String(),
                        PropertyType = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        Insurance = c.Int(nullable: false),
                        Insurances_InsurancesId = c.Int(),
                    })
                .PrimaryKey(t => t.RealEstateInsuranceId)
                .ForeignKey("dbo.Insurances", t => t.Insurances_InsurancesId)
                .Index(t => t.Insurances_InsurancesId);
            
            CreateTable(
                "dbo.TravelInsurances",
                c => new
                    {
                        TravelInsuranceId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        NumberOfInsuredPersons = c.Int(nullable: false),
                        NumberOfInsuredPersonsOverAge26 = c.Int(nullable: false),
                        NumberOfInsuredPersonsOverAge65 = c.Int(nullable: false),
                        NumberOfInsuredPersonsBetween26and65 = c.Int(nullable: false),
                        InsuranceCost = c.Double(nullable: false),
                        Insurance = c.Int(nullable: false),
                        Insurances_InsurancesId = c.Int(),
                    })
                .PrimaryKey(t => t.TravelInsuranceId)
                .ForeignKey("dbo.Insurances", t => t.Insurances_InsurancesId)
                .Index(t => t.Insurances_InsurancesId);
            
            CreateTable(
                "dbo.AdditionalOptions",
                c => new
                    {
                        AdditionalOptionsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TravelInsurance_TravelInsuranceId = c.Int(),
                    })
                .PrimaryKey(t => t.AdditionalOptionsId)
                .ForeignKey("dbo.TravelInsurances", t => t.TravelInsurance_TravelInsuranceId)
                .Index(t => t.TravelInsurance_TravelInsuranceId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TravelInsurance_TravelInsuranceId = c.Int(),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.TravelInsurances", t => t.TravelInsurance_TravelInsuranceId)
                .Index(t => t.TravelInsurance_TravelInsuranceId);
            
            AddColumn("dbo.ClientDatas", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientDatas", "Adress", c => c.String());
            AddColumn("dbo.ClientDatas", "CarUsingPeriod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "TravelInsurance_TravelInsuranceId", "dbo.TravelInsurances");
            DropForeignKey("dbo.TravelInsurances", "Insurances_InsurancesId", "dbo.Insurances");
            DropForeignKey("dbo.AdditionalOptions", "TravelInsurance_TravelInsuranceId", "dbo.TravelInsurances");
            DropForeignKey("dbo.RealEstateInsurances", "Insurances_InsurancesId", "dbo.Insurances");
            DropForeignKey("dbo.Vehicles", "VehicleId", "dbo.CarInsurances");
            DropForeignKey("dbo.TypeOfCarInsurances", "TypeOfCarInsuranceId", "dbo.CarInsurances");
            DropForeignKey("dbo.Payments", "PaymentId", "dbo.CarInsurances");
            DropForeignKey("dbo.CarInsurances", "Insurances_InsurancesId", "dbo.Insurances");
            DropForeignKey("dbo.Offenders", "OffendersId", "dbo.CarInsuranceApplications");
            DropForeignKey("dbo.CarInsuranceApplications", "CarInsurance_CarInsuranceId", "dbo.CarInsurances");
            DropForeignKey("dbo.Discounts", "DiscountId", "dbo.Clients");
            DropIndex("dbo.Regions", new[] { "TravelInsurance_TravelInsuranceId" });
            DropIndex("dbo.AdditionalOptions", new[] { "TravelInsurance_TravelInsuranceId" });
            DropIndex("dbo.TravelInsurances", new[] { "Insurances_InsurancesId" });
            DropIndex("dbo.RealEstateInsurances", new[] { "Insurances_InsurancesId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleId" });
            DropIndex("dbo.TypeOfCarInsurances", new[] { "TypeOfCarInsuranceId" });
            DropIndex("dbo.Payments", new[] { "PaymentId" });
            DropIndex("dbo.Offenders", new[] { "OffendersId" });
            DropIndex("dbo.CarInsuranceApplications", new[] { "CarInsurance_CarInsuranceId" });
            DropIndex("dbo.CarInsurances", new[] { "Insurances_InsurancesId" });
            DropIndex("dbo.Discounts", new[] { "DiscountId" });
            DropColumn("dbo.ClientDatas", "CarUsingPeriod");
            DropColumn("dbo.ClientDatas", "Adress");
            DropColumn("dbo.ClientDatas", "BirthDate");
            DropTable("dbo.Regions");
            DropTable("dbo.AdditionalOptions");
            DropTable("dbo.TravelInsurances");
            DropTable("dbo.RealEstateInsurances");
            DropTable("dbo.Vehicles");
            DropTable("dbo.TypeOfCarInsurances");
            DropTable("dbo.Payments");
            DropTable("dbo.Offenders");
            DropTable("dbo.CarInsuranceApplications");
            DropTable("dbo.CarInsurances");
            DropTable("dbo.Discounts");
        }
    }
}
