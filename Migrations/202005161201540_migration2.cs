namespace Gokhan_Selale_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KursKayitlars", "Kurs_KursID", "dbo.Kurslars");
            DropIndex("dbo.KursKayitlars", new[] { "Kurs_KursID" });
            AddColumn("dbo.Kurslars", "KursKayitlar_ID", c => c.Int());
            CreateIndex("dbo.Kurslars", "KursKayitlar_ID");
            AddForeignKey("dbo.Kurslars", "KursKayitlar_ID", "dbo.KursKayitlars", "ID");
            DropColumn("dbo.KursKayitlars", "Kurs_KursID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KursKayitlars", "Kurs_KursID", c => c.Int());
            DropForeignKey("dbo.Kurslars", "KursKayitlar_ID", "dbo.KursKayitlars");
            DropIndex("dbo.Kurslars", new[] { "KursKayitlar_ID" });
            DropColumn("dbo.Kurslars", "KursKayitlar_ID");
            CreateIndex("dbo.KursKayitlars", "Kurs_KursID");
            AddForeignKey("dbo.KursKayitlars", "Kurs_KursID", "dbo.Kurslars", "KursID");
        }
    }
}
