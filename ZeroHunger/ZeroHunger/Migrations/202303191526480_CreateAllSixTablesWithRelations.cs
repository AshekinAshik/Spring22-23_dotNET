namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllSixTablesWithRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Contact = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpProdReqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                        Emp_Id = c.Int(nullable: false),
                        ProdReq_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Emp_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProdReqs", t => t.ProdReq_Id, cascadeDelete: true)
                .Index(t => t.Emp_Id)
                .Index(t => t.ProdReq_Id);
            
            CreateTable(
                "dbo.ProdReqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Prod_Id = c.Int(nullable: false),
                        Req_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Prod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Requests", t => t.Req_Id, cascadeDelete: true)
                .Index(t => t.Prod_Id)
                .Index(t => t.Req_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Quantity = c.Int(nullable: false),
                        R_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.R_ID, cascadeDelete: true)
                .Index(t => t.R_ID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReqDate = c.DateTime(nullable: false),
                        ExpDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpProdReqs", "ProdReq_Id", "dbo.ProdReqs");
            DropForeignKey("dbo.ProdReqs", "Req_Id", "dbo.Requests");
            DropForeignKey("dbo.ProdReqs", "Prod_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "R_ID", "dbo.Restaurants");
            DropForeignKey("dbo.EmpProdReqs", "Emp_Id", "dbo.Employees");
            DropIndex("dbo.Products", new[] { "R_ID" });
            DropIndex("dbo.ProdReqs", new[] { "Req_Id" });
            DropIndex("dbo.ProdReqs", new[] { "Prod_Id" });
            DropIndex("dbo.EmpProdReqs", new[] { "ProdReq_Id" });
            DropIndex("dbo.EmpProdReqs", new[] { "Emp_Id" });
            DropTable("dbo.Requests");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Products");
            DropTable("dbo.ProdReqs");
            DropTable("dbo.EmpProdReqs");
            DropTable("dbo.Employees");
        }
    }
}
