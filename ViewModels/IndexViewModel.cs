using SistemaCalilficaciones.Models;
using System.Collections.Generic;

namespace SistemaCalilficaciones.ViewModels
{
    public class IndexViewModel
    {
        public List<Asignatura> AsignaturasImpartidas { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}