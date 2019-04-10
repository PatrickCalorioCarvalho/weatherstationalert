namespace WeatherStationAlert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherStations", "Temperatura", c => c.Single(nullable: false));
            AddColumn("dbo.WeatherStations", "Umidade", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeatherStations", "Umidade");
            DropColumn("dbo.WeatherStations", "Temperatura");
        }
    }
}
