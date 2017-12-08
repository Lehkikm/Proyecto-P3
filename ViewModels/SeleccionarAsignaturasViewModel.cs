using System.Collections.Generic;
using SistemaCalilficaciones.Models;

namespace SistemaCalilficaciones.ViewModels
{
    public class SeleccionarAsignaturasViewModel
    {
        public List<Asignatura> Asignaturas { get; set; } 
        public bool MateriaSeleccionada { get; set; }
    }
}