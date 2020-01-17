using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class User
    {
        [Required(ErrorMessage = "El ID del Usuario es requerido...")]
        [Display(Name = "Usuario:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Anote del password del Usuario...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }




    }
}
