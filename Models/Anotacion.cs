using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCalilficaciones.Models {
    public class Anotacion 
    {
        public int Id { get; set; }

        [Required]
        [Display (Name="Fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Display (Name="Titulo")]
        public string Titulo { get; set; }

        [Required]
        [Display (Name="Cuerpo")]
        public string Cuerpo { get; set; }

        public string UserId { get; set;}

        [ForeignKey ("UserId")]
        public ApplicationUser User { get; set; }

        public int AsignaturaId { get; set; }

        [ForeignKey ("AsignaturaId")]
        public Asignatura Asignatura { get; set; }

    }
}