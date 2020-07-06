namespace Gokhan_Selale_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migraton5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.KursKayitlars", new[] { "Kurs_KursID" });
            AlterColumn("dbo.KursKayitlars", "Kurs_KursID", c => c.Int(nullable: false));
            CreateIndex("dbo.KursKayitlars", "Kurs_KursID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.KursKayitlars", new[] { "Kurs_KursID" });
            AlterColumn("dbo.KursKayitlars", "Kurs_KursID", c => c.Int());
            CreateIndex("dbo.KursKayitlars", "Kurs_KursID");
        }
    }
}
