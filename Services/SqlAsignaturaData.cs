using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SistemaCalilficaciones.Data;
using SistemaCalilficaciones.Models;

namespace SistemaCalilficaciones.Services {
    public class SqlAsignaturaData : IAsignaturaData {
        private ApplicationDbContext _contexto;

        public SqlAsignaturaData (ApplicationDbContext context) {
            _contexto = context;
        }

        public IEnumerable<Asignatura> GetAsignaturas () {
            var asignaturas = _contexto.Asignaturas.OrderBy (a => a.Nombre);
            return asignaturas;
        }

        public Asignatura Add (Asignatura asignatura) {
            _contexto.Asignaturas.Add (asignatura);
            _contexto.SaveChanges();
            return asignatura;
        }

        public Asignatura Get (int id) {
            var busqueda = _contexto.Asignaturas.FirstOrDefault (a => a.Id == id);
            return busqueda;
        }

        public Asignatura Update (Asignatura asignatura) {
            _contexto.Attach (asignatura).State = EntityState.Modified;
            _contexto.SaveChanges ();

            return asignatura;
        }
    }
}