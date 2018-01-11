namespace InsuranceRestSerwer.Migrations.Insurance
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WhyClientDataDosentWork : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ClientDatas", "PeselNumber");
            DropColumn("dbo.ClientDatas", "BirthDate");
            DropColumn("dbo.ClientDatas", "Adress");
            DropColumn("dbo.ClientDatas", "CarUsingPeriod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientDatas", "CarUsingPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.ClientDatas", "Adress", c => c.String());
            AddColumn("dbo.ClientDatas", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ClientDatas", "PeselNumber", c => c.Int(nullable: false));
        }
    }
}
