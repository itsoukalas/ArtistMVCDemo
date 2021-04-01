namespace ArtistMVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYoutube : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Youtube", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "Youtube");
        }
    }
}
