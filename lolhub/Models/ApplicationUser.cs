using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lolhub.Models
{
    public class ApplicationUser:IdentityUser
    {
        public IList<Paylasim> Paylasimlar { get; set; }
    }
}
