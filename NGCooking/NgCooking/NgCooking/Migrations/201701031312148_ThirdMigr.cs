namespace NgCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recettes", "name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recettes", "name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
