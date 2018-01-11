namespace InsuranceRestSerwer.Migrations.Insurance
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientDatas",
                c => new
                    {
                        ClientDataId = c.Int(nullable: false),
                        PeselNumber = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Adress = c.String(),
                        CarUsingPeriod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientDataId)
                .ForeignKey("dbo.Clients", t => t.ClientDataId)
                .Index(t => t.ClientDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientDatas", "ClientDataId", "dbo.Clients");
            DropIndex("dbo.ClientDatas", new[] { "ClientDataId" });
            DropTable("dbo.ClientDatas");
        }
    }
}
