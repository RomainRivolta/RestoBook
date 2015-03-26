namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoBookDBContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NomRestaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Type_Fk = c.Int(nullable: false),
                        Id_Ville_Fk = c.Int(nullable: false),
                        Nom = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeRestaurants", t => t.Id_Type_Fk, cascadeDelete: true)
                .Index(t => t.Id_Type_Fk);
            
            CreateTable(
                "dbo.TypeRestaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VilleRestaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ville = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VilleRestaurantNomRestaurants",
                c => new
                    {
                        VilleRestaurant_Id = c.Int(nullable: false),
                        NomRestaurant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VilleRestaurant_Id, t.NomRestaurant_Id })
                .ForeignKey("dbo.VilleRestaurants", t => t.VilleRestaurant_Id, cascadeDelete: true)
                .ForeignKey("dbo.NomRestaurants", t => t.NomRestaurant_Id, cascadeDelete: true)
                .Index(t => t.VilleRestaurant_Id)
                .Index(t => t.NomRestaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VilleRestaurantNomRestaurants", "NomRestaurant_Id", "dbo.NomRestaurants");
            DropForeignKey("dbo.VilleRestaurantNomRestaurants", "VilleRestaurant_Id", "dbo.VilleRestaurants");
            DropForeignKey("dbo.NomRestaurants", "Id_Type_Fk", "dbo.TypeRestaurants");
            DropIndex("dbo.VilleRestaurantNomRestaurants", new[] { "NomRestaurant_Id" });
            DropIndex("dbo.VilleRestaurantNomRestaurants", new[] { "VilleRestaurant_Id" });
            DropIndex("dbo.NomRestaurants", new[] { "Id_Type_Fk" });
            DropTable("dbo.VilleRestaurantNomRestaurants");
            DropTable("dbo.VilleRestaurants");
            DropTable("dbo.TypeRestaurants");
            DropTable("dbo.NomRestaurants");
        }
    }
}
