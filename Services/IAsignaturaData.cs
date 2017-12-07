using System;
using System.Collections.Generic;
using SistemaCalilficaciones.Models;

namespace SistemaCalilficaciones.Services
{
    public interface IAsignaturaData
    {
        IEnumerable<Asignatura> GetAsignaturas();
        Asignatura Get (int id);
        Asignatura Add (Asignatura asignatura);
        Asignatura Update (Asignatura asignatura);
    }
}