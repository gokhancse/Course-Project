namespace Gokhan_Selale_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgrtn7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.KursKayitlars", new[] { "Kurs_KursID" });
            RenameColumn(table: "dbo.KursKayitlars", name: "Kurs_KursID", newName: "Kurslar_KursID");
            AlterColumn("dbo.KursKayitlars", "Kurslar_KursID", c => c.Int());
            CreateIndex("dbo.KursKayitlars", "Kurslar_KursID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.KursKayitlars", new[] { "Kurslar_KursID" });
            AlterColumn("dbo.KursKayitlars", "Kurslar_KursID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.KursKayitlars", name: "Kurslar_KursID", newName: "Kurs_KursID");
            CreateIndex("dbo.KursKayitlars", "Kurs_KursID");
        }
    }
}
