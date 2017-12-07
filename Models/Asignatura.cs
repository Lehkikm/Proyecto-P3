using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCalilficaciones.Models {
    public class Asignatura {
        // Datos
        public int Id { get; set; }

        [Display (Name="Nombre"), MaxLength(80)]
        public string Nombre { get; set; }

        [Display (Name="Aula")]
        public int Aula { get; set; }

        // Horario de la asignatura
        [Display (Name="Primer día")]
        public DiasSemana Dia1 { get; set; }

        [Display (Name="Segundo día")]
        public DiasSemana Dia2 { get; set; }

        [Display (Name="Hora de entrada")]
        public DateTime HoraEntrada { get; set; }

        [Display (Name="Hora de salida")]
        public DateTime HoraSalida { get; set; }

        [Display (Name="Escoge al profesor")]
        public string UserId { get; set; }
        
        public ApplicationUser User { get; set; }
    }
}