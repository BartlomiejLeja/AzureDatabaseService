namespace InsuranceRestSerwer.Migrations.Insurance
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IItshouldworks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RealEstateInsurances", "Insurances_InsurancesId", "dbo.Insurances");
            DropIndex("dbo.RealEstateInsurances", new[] { "Insurances_InsurancesId" });
            RenameColumn(table: "dbo.RealEstateInsurances", name: "Insurances_InsurancesId", newName: "InsurancesId");
            AlterColumn("dbo.RealEstateInsurances", "InsurancesId", c => c.Int(nullable: false));
            CreateIndex("dbo.RealEstateInsurances", "InsurancesId");
            AddForeignKey("dbo.RealEstateInsurances", "InsurancesId", "dbo.Insurances", "InsurancesId", cascadeDelete: true);
            DropColumn("dbo.RealEstateInsurances", "Insurance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealEstateInsurances", "Insurance", c => c.Int(nullable: false));
            DropForeignKey("dbo.RealEstateInsurances", "InsurancesId", "dbo.Insurances");
            DropIndex("dbo.RealEstateInsurances", new[] { "InsurancesId" });
            AlterColumn("dbo.RealEstateInsurances", "InsurancesId", c => c.Int());
            RenameColumn(table: "dbo.RealEstateInsurances", name: "InsurancesId", newName: "Insurances_InsurancesId");
            CreateIndex("dbo.RealEstateInsurances", "Insurances_InsurancesId");
            AddForeignKey("dbo.RealEstateInsurances", "Insurances_InsurancesId", "dbo.Insurances", "InsurancesId");
        }
    }
}
