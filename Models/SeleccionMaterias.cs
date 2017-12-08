namespace SistemaCalilficaciones.Models
{
    public class SeleccionMaterias
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }  
    }
}