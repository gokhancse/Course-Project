using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Gokhan_Selale_Project.Models
{
    public class Context:DbContext
    {
        public Context() : base("ConStr")
        {
            Database.SetInitializer(new NullDatabaseInitializer<Context>());
        }
        //Veritabanımızda oluşmasını istediğimiz tablolara karşılık gelmek üzere tüm sınıflarımızı DBSet içerisinde çağırmalıyız.
        public DbSet<Kurslar> Kurslars { get; set; }
        public DbSet<KursKayitlar> KursKayitlars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kurslar>()
              .HasMany(e => e.KursKayitlar)
              .WithRequired(e => e.Kurslar)
              .WillCascadeOnDelete(false);
        }
    }
}