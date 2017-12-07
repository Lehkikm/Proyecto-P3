using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SistemaCalilficaciones.Models.AccountViewModels 
{
    public class RegisterViewModel 
    {
        [Required]
        [Display (Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display (Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength (100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType (DataType.Password)]
        [Display (Name = "Contraseña")]
        public string Password { get; set; }

        [DataType (DataType.Password)]
        [Display (Name = "Confirma la contraseña")]
        [Compare ("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        // Usas esta para almacenar el tipo de usuario en el controlador correspondiente (AccountController)
        public List<IdentityRole> TipoUsuario { get; set; }

        [Required]
        [Display (Name="Tipo de Usuario")]
        public string TipoUsuarioSeleccionado { get; set; }
    }
}