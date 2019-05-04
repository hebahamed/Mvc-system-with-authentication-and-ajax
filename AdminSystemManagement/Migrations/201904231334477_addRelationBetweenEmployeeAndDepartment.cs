namespace AdminSystemManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationBetweenEmployeeAndDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Fk_DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "Fk_DepartmentId");
            AddForeignKey("dbo.Employee", "Fk_DepartmentId", "dbo.Department", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Fk_DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Fk_DepartmentId" });
            DropColumn("dbo.Employee", "Fk_DepartmentId");
        }
    }
}
