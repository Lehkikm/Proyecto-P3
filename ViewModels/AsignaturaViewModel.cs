using System.Collections.Generic;
using SistemaCalilficaciones.Models;

namespace SistemaCalilficaciones.ViewModels
{
    public class AsignaturaViewModel 
    {
        public Asignatura Asignatura { get; set; }

        public List<Anotacion> Anotaciones { get; set; }

        public Anotacion Anotacion { get; set; }
    }
}