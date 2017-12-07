using Microsoft.AspNetCore.Http;
using SistemaCalilficaciones.Models;

namespace SistemaCalilficaciones.ViewModels
{
    public class EditarPerfilUsuarioViewModel : ApplicationUser
    {
        public IFormFile ImagenPerfil { get; set; }
    }
}