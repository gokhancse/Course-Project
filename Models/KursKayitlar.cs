using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gokhan_Selale_Project.Models
{
    public class KursKayitlar
    {
        public int ID { get; set; }
        public int GelenKisiSayisi { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Tarih formatına uygun giriniz!")]
        public DateTime Tarih { get; set; }
        public int KursId { get; set; }
        public virtual Kurslar Kurslar { get; set; }
    }
}