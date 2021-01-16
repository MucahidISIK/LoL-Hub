using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lolhub.Models;
using lolhub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace lolhub.Data
{
    public class Context : DbContext
    {
        public DbSet<Paylasim> Paylasimlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NQFHQFF; Database=DBlolhub; trusted_connection=true;");
        }

    }
}
