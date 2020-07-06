namespace Gokhan_Selale_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kurslars", "KursKayitlar_ID", "dbo.KursKayitlars");
            DropIndex("dbo.Kurslars", new[] { "KursKayitlar_ID" });
            AddColumn("dbo.KursKayitlars", "Kurs_KursID", c => c.Int());
            CreateIndex("dbo.KursKayitlars", "Kurs_KursID");
            AddForeignKey("dbo.KursKayitlars", "Kurs_KursID", "dbo.Kurslars", "KursID");
            DropColumn("dbo.Kurslars", "KursKayitlar_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kurslars", "KursKayitlar_ID", c => c.Int());
            DropForeignKey("dbo.KursKayitlars", "Kurs_KursID", "dbo.Kurslars");
            DropIndex("dbo.KursKayitlars", new[] { "Kurs_KursID" });
            DropColumn("dbo.KursKayitlars", "Kurs_KursID");
            CreateIndex("dbo.Kurslars", "KursKayitlar_ID");
            AddForeignKey("dbo.Kurslars", "KursKayitlar_ID", "dbo.KursKayitlars", "ID");
        }
    }
}
