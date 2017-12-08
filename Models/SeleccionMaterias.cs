namespace SistemaCalilficaciones.Models
{
    public class SeleccionMaterias
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }  
    }
}