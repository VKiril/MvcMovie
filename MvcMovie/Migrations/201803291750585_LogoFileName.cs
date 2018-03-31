namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogoFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "LogoFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "LogoFileName");
        }
    }
}
