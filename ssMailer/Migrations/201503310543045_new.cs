namespace ssMailer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emailer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailId = c.String(maxLength: 100),
                        UserName = c.String(maxLength: 50),
                        IsSent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emailer");
        }
    }
}
