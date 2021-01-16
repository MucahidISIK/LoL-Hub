using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lolhub.Models
{
    public class Paylasim
    {
        [Key]
        public int PaylasimID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string VLink { get; set; }
        public string GLink { get; set; }
        public string KullaniciAd { get; set; }

        
    }
}
