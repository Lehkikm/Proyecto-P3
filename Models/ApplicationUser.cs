using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SistemaCalilficaciones.Models {
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser {
        [MaxLength (60)]
        public string Nombre { get; set; }

        [MaxLength (10)]
        [Display (Name = "Teléfono")]
        public string Telefono { get; set; }

        [MaxLength (10)]
        [Display (Name = "Cédula")]
        public string Cedula { get; set; }

        [Display (Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display (Name = "Dirección")]
        [MaxLength (300)]
        public string Direccion { get; set; }

        [Display (Name="Seleccionar una foto")]
        public string UrlFotoPerfil { get; set; }
    }
}