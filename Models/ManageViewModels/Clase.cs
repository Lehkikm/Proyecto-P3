using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaCalilficaciones.Models.ManageViewModels 
{
    public class Clase 
    {
        [Required]
        public int IdProfesor { get; set; }

        [Required]
        public int IdAsignatura { get; set; }

        [Required]
        public Anotacion Anotacion { get; set; }
    }
}