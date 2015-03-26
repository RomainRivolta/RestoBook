using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestoBook.Models
{
    public class TypeRestaurant
    {
        public int Id { get; set; }
        [Remote("IsTypeAvailable", "Restaurant", ErrorMessage = "Ce type de cuisne existe déjà")]
        public string Type { get; set; }
        public TypeRestaurant()
        {
            NomRestaurants = new List<NomRestaurant>();
        }
        public virtual ICollection<NomRestaurant> NomRestaurants { get; set; }

    }

    public partial class VilleRestaurant
    {

        public int Id { get; set; }
        [Remote("IsVilleAvailable", "Restaurant", ErrorMessage = "Cette ville existe déjà")]
        public string Ville { get; set; }
        public VilleRestaurant()
        {
            NomRestaurants = new List<NomRestaurant>();
        }
        public virtual ICollection<NomRestaurant> NomRestaurants { get; set; }

    }

    public class NomRestaurant
    {
        public int Id { get; set; }
        public int Id_Type_Fk { get; set; }
        [Required(ErrorMessage="Champs requis")]
        [Display(Name="Nom")]
        public string Nom { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Id_Type_Fk")]
        public virtual TypeRestaurant TypeRestaurants { get; set; }
        public virtual ICollection<VilleRestaurant> VilleRestaurants { get; set; }
    }

    public class BigRestaurant
    {
        //public int Id { get; set; }
        public NomRestaurant NomRestaurants { get; set; }
        public VilleRestaurant VilleRestaurants { get; set; }
        public TypeRestaurant TypeRestaurants { get; set; }
    }

    public class RestoBookDBContext:AppDbContext
    {
        public DbSet<VilleRestaurant> VilleRestaurant { get; set; }
        public DbSet<NomRestaurant> NomRestaurant { get; set; }
        public DbSet<TypeRestaurant> TypeRestaurant { get; set; }
    }   
}