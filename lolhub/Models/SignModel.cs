using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lolhub.Models
{
    public class SignModel
    {
        [Required]
        public string KullaniciAd { get; set; }

        [Required]
        public string KullaniciSifre { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
