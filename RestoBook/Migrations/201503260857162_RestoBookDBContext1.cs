namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoBookDBContext1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NomRestaurants", "Id_Ville_Fk");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NomRestaurants", "Id_Ville_Fk", c => c.Int(nullable: false));
        }
    }
}
