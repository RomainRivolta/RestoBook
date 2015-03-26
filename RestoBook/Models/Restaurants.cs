using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoBook.Models
{
    public class Restaurants
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }



    public class Ville
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }


    public class RestoBookDBContext : DbContext
    {
        public DbSet<Restaurants> restaurant { get; set; }
        public DbSet<Ville> ville { get; set; }
    }
}