using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL.Data
{
    public class VerkoopBeheerEntities: DbContext
    {
        public VerkoopBeheerEntities(): base ("VerkoopbeheerDB")
        {
          

        }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderlijn> Orderlijnen { get; set; }
        public DbSet<Werknemer> Werknemers { get; set; }
        public DbSet<Product> Producten { get; set; }
    }

}
