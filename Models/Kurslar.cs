using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gokhan_Selale_Project.Models
{
    public class Kurslar
    {
        [Key]
        public int KursID { get; set; }

        [Required(ErrorMessage = "Lütfen makale başlığını giriniz!")]
        [StringLength(50, ErrorMessage = "Başlık 50 karakterden uzun olmamalıdır!")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Lütfen makale içeriğini giriniz!")]
        [DataType(DataType.Html, ErrorMessage = "İçeriği Html formatına uygun giriniz!")]
        public string KursAd { get; set; }
       
        public virtual ICollection<KursKayitlar> KursKayitlar { get; set; }
    }
}