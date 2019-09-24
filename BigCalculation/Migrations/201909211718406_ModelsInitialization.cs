namespace BigCalculation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsInitialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalculationHistories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstNumber = c.String(),
                        SecondNumber = c.String(),
                        SummationResult = c.String(),
                        UserId = c.String(maxLength: 128),
                        CreateTime = c.DateTime(),
                        LastModifiedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        LastModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        CreateTime = c.DateTime(),
                        LastModifiedTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        LastModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalculationHistories", "UserId", "dbo.Users");
            DropIndex("dbo.CalculationHistories", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.CalculationHistories");
        }
    }
}
