namespace Flights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Start = c.String(nullable: false, maxLength: 40),
                        Date1 = c.DateTime(nullable: false),
                        Time1 = c.String(nullable: false),
                        Meta = c.String(nullable: false),
                        Date2 = c.DateTime(nullable: false),
                        Time2 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Type = c.String(nullable: false, maxLength: 80),
                        Flight_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Flights", t => t.Flight_ID)
                .Index(t => t.Flight_ID);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planes", "Flight_ID", "dbo.Flights");
            DropIndex("dbo.Planes", new[] { "Flight_ID" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Planes");
            DropTable("dbo.Flights");
        }
    }
}
