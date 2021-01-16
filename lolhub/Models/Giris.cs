using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace lolhub.Models
{
    [Authorize(Roles ="User")]
    public class Giris
    {
        [Key]
        public string KullaniciID { get; set; }

        public string  Email { get; set; }

        [Required]
        public string KullaniciAd { get; set; }

        [Required]
        public string KullaniciSifre { get; set; }
        public string Url { get; set; }

    }
}
