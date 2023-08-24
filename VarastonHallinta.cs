using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TietokantaHarjoitus
{
    public class VarastonHallinta :DbContext
    { 
        public DbSet<Tuote> Tuotteet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;Initial Catalog=VarastonHallinta;User id=sa;Password=GkeOqjcp5762?;MultipleActiveResultSets=true;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connection);
        }
    


    }
}
