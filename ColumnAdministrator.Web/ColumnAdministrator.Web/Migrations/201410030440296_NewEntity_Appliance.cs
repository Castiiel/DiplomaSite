namespace ColumnAdministrator.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewEntity_Appliance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Price = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        LastName = c.String(),
                        InStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appliances");
        }
    }
}
