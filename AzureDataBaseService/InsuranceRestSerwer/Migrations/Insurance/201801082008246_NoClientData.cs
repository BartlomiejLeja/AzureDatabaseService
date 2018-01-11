namespace InsuranceRestSerwer.Migrations.Insurance
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoClientData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients");
            DropIndex("dbo.ClientDatas", new[] { "ClientDataId" });
            DropTable("dbo.ClientDatas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientDatas",
                c => new
                    {
                        ClientDataId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientDataId);
            
            CreateIndex("dbo.ClientDatas", "ClientDataId");
            AddForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients", "ClientId");
        }
    }
}
