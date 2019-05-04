namespace AdminSystemManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "DateProperty", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "DateProperty");
        }
    }
}
