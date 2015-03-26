using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestoBook.Models
{
    public class Register
    {
        //[Required(ErrorMessage = "Champs requis")]
        //[Display(Name = "Nom")]
        //public string Nom { get; set; }

        //[Required(ErrorMessage = "Champs requis")]
        //[Display(Name = "Prénom")]
        //public string Prenom { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            ErrorMessage = "Email incorrect")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [Display(Name = "Nom utilisateur")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Champs requis")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe sont différents")]
        public string ConfirmPassword { get; set; }


        //[Required(ErrorMessage = "Champs requis")]
        //[Display(Name = "Ville")]
        //public string Ville { get; set; }
    }

    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [System.Web.Mvc.HiddenInput]
        public string ReturnUrl { get; set; }
    }
}