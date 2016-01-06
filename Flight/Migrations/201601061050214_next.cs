namespace Flights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Planes", "Flight_ID", "dbo.Flights");
            DropIndex("dbo.Planes", new[] { "Flight_ID" });
            AddColumn("dbo.Flights", "Plane_ID", c => c.Int());
            CreateIndex("dbo.Flights", "Plane_ID");
            AddForeignKey("dbo.Flights", "Plane_ID", "dbo.Planes", "ID");
            DropColumn("dbo.Planes", "Flight_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Planes", "Flight_ID", c => c.Int());
            DropForeignKey("dbo.Flights", "Plane_ID", "dbo.Planes");
            DropIndex("dbo.Flights", new[] { "Plane_ID" });
            DropColumn("dbo.Flights", "Plane_ID");
            CreateIndex("dbo.Planes", "Flight_ID");
            AddForeignKey("dbo.Planes", "Flight_ID", "dbo.Flights", "ID");
        }
    }
}
