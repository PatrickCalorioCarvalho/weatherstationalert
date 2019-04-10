namespace WeatherStationAlert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeatherStations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Setor = c.Int(nullable: false),
                        Pluviosidade = c.Single(nullable: false),
                        Inclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeatherStations");
        }
    }
}
