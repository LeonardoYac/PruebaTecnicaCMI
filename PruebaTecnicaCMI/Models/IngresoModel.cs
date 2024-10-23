using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCMI.Models
{
    public class IngresoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo CodigoEmpleado es obligatorio")]
        public string? CodigoEmpleado { get; set; }

        [Required(ErrorMessage = "El campo HoraEntrada es obligatorio")]
        public TimeSpan HoraEntrada { get; set; }

        [Required(ErrorMessage = "El campo HoraSalida es obligatorio")]
        public TimeSpan HoraSalida { get; set; }

        public string? NombreUsuario { get; set; }

        public string? TipoHoras { get; set; }
    }
}
