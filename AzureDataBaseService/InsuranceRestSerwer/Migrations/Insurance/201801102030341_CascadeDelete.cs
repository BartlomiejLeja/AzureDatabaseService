namespace InsuranceRestSerwer.Migrations.Insurance
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients");
            AddForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients", "ClientId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients");
            AddForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients", "ClientId");
        }
    }
}
