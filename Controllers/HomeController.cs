using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaCalilficaciones.Data;
using SistemaCalilficaciones.Models;
using SistemaCalilficaciones.Services;
using SistemaCalilficaciones.ViewModels;

namespace SistemaCalilficaciones.Controllers {
    public class HomeController : Controller {
        private IAsignaturaData _asignaturaData; // Permite gestionar (CRUD) los datos de mis asignaturas.
        private readonly UserManager<ApplicationUser> _userManager; // Permite manejar (CRUD) el usuario logueado.
        private readonly RoleManager<IdentityRole> _roleManager; // Permite manejar (CRUD) los roles.
        private ApplicationDbContext _context; // Permite manejar (CRUD) la base de datos.

        public HomeController (UserManager<ApplicationUser> userManager, IAsignaturaData asignaturaData, RoleManager<IdentityRole> roleManager, ApplicationDbContext context) {
            _userManager = userManager;
            _asignaturaData = asignaturaData;
            _roleManager = roleManager;
            _context = context;
        }

        // Verifica que existan "roles" almacenados en la base de datos.
        public async Task<IActionResult> Inicio () {
            if (_context.Roles.Count () == 0) {
                // Create Roles
                string[] roles = { "Estudiante", "Profesor" };
                foreach (var role in roles) {
                    await _roleManager.CreateAsync (new IdentityRole (role));
                }
                return RedirectToAction ("Index");
            } else
                return RedirectToAction ("Index");
        }

        // Gestiona la página principal del Profesor.
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index () {
            // Si es un estudiante, vete al Index de estudiante.
            var usuario = await _userManager.GetUserAsync (User);
            var role = await _userManager.GetRolesAsync (usuario);

            if (role.First () == "Estudiante") {
                return RedirectToAction ("IndexUsuario");
            }

            var viewModel = new IndexViewModel () {
                Usuario = usuario,
                AsignaturasImpartidas = _context.Asignaturas.Where(a => a.UserId == usuario.Id).ToList()
            };
            return View (viewModel);
        }

        // Gestiona la página principal del Estudiante
        [HttpGet]
        public async Task<IActionResult> IndexEstudiante () {
            var viewModel = new IndexViewModel () {
                Usuario = await _userManager.GetUserAsync (User)
            };
            return View (viewModel);
        }

        // Muestra los datos de una Asignatura
        [HttpGet]
        public IActionResult Asignatura (int id) {
            var asignatura = _context.Asignaturas.Where(a => a.Id == id).FirstOrDefault();
            var viewModel = new AsignaturaViewModel()
            {
                Asignatura = asignatura
            };
            return View (viewModel);
        }

        // Gestiona las asignaturas
        [HttpGet]
        public IActionResult AgregarAsignatura () {
            var viewModel = new AgregarAsignaturaViewModel () {
                Profesores = _userManager.Users.ToList ()
            };
            return View (viewModel);
        }

        [HttpPost]
        public IActionResult AgregarAsignatura (AgregarAsignaturaViewModel viewModel) {
            if (ModelState.IsValid) {
                var asignatura = new Asignatura () {
                    Nombre = viewModel.Nombre,
                    Aula = viewModel.Aula,
                    Dia1 = viewModel.Dia1,
                    Dia2 = viewModel.Dia2,
                    HoraEntrada = viewModel.HoraEntrada,
                    HoraSalida = viewModel.HoraSalida,
                    UserId = viewModel.UserId,
                };

                _asignaturaData.Add (asignatura);
                return RedirectToAction ("Index");
            } else {
                return View ();
            }
        }

        // Gestiona el perfil del usuario.
        [HttpGet]
        public async Task<IActionResult> PerfilUsuario () {
            var usuarioLogueado = await _userManager.GetUserAsync (User);
            
            var model = new EditarPerfilUsuarioViewModel () {
                Nombre = usuarioLogueado.Nombre,
                Telefono = usuarioLogueado.Telefono,
                Cedula = usuarioLogueado.Cedula,
                FechaNacimiento = usuarioLogueado.FechaNacimiento,
                Direccion = usuarioLogueado.Direccion,
                UrlFotoPerfil = usuarioLogueado.UrlFotoPerfil
            };
            return View (model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PerfilUsuario (EditarPerfilUsuarioViewModel viewModel) {
            if (ModelState.IsValid) {
                var usuarioLogueado = await _userManager.GetUserAsync (User);
                var imagenPerfil = viewModel.ImagenPerfil;

                // Guardando foto de perfil en servidor.
                var path = Path.Combine (Directory.GetCurrentDirectory (), "wwwroot/images", imagenPerfil.FileName);
                using (var stream = new FileStream (path, FileMode.Create)) {
                    await imagenPerfil.CopyToAsync (stream);
                }

                usuarioLogueado.UrlFotoPerfil = "/images/" + imagenPerfil.FileName; // Él sabe que debe guardar en wwwroot porque así se lo indiqué al momento de inyectar el FileProvider.

                // Creando un objeto de tipo usuario para su posterior uso como modelo de almacenamiento.

                usuarioLogueado.Nombre = viewModel.Nombre;
                usuarioLogueado.Telefono = viewModel.Telefono;
                usuarioLogueado.Cedula = viewModel.Cedula;
                usuarioLogueado.FechaNacimiento = viewModel.FechaNacimiento;
                usuarioLogueado.Direccion = viewModel.Direccion;
                usuarioLogueado.UrlFotoPerfil = usuarioLogueado.UrlFotoPerfil;

                await _userManager.UpdateAsync(usuarioLogueado);

                return RedirectToAction("PerfilUsuario");
            } else {
                return View ();
            }
        }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}