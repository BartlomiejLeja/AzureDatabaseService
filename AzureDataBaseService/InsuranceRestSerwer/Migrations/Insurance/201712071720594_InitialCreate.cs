namespace InsuranceRestSerwer.Migrations.Insurance
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientDatas",
                c => new
                    {
                        ClientDataId = c.Int(nullable: false),
                        PeselNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientDataId)
                .ForeignKey("dbo.Clients", t => t.ClientDataId)
                .Index(t => t.ClientDataId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        InsurancesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsurancesId)
                .ForeignKey("dbo.Clients", t => t.InsurancesId)
                .Index(t => t.InsurancesId);
            
            CreateTable(
                "dbo.HealthInsurances",
                c => new
                    {
                        HealthInsuranceId = c.Int(nullable: false, identity: true),
                        Insurance = c.Int(nullable: false),
                        Insurances_InsurancesId = c.Int(),
                    })
                .PrimaryKey(t => t.HealthInsuranceId)
                .ForeignKey("dbo.Insurances", t => t.Insurances_InsurancesId)
                .Index(t => t.Insurances_InsurancesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients");
            DropForeignKey("dbo.HealthInsurances", "Insurances_InsurancesId", "dbo.Insurances");
            DropForeignKey("dbo.Insurances", "InsurancesId", "dbo.Clients");
            DropIndex("dbo.HealthInsurances", new[] { "Insurances_InsurancesId" });
            DropIndex("dbo.Insurances", new[] { "InsurancesId" });
            DropIndex("dbo.ClientDatas", new[] { "ClientDataId" });
            DropTable("dbo.HealthInsurances");
            DropTable("dbo.Insurances");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientDatas");
        }
    }
}
