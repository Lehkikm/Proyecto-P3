using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SistemaCalilficaciones.Models;

namespace SistemaCalilficaciones.ViewModels {
    public class AgregarAsignaturaViewModel : Asignatura
    {
        public List<ApplicationUser> Profesores { get; set; }
    }
}