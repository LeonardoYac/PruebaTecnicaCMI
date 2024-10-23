using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCMI.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        
        
        [Required(ErrorMessage = "El campo Usuario es obligatorio")]
        public string? Usuario { get; set; }
        
        
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        public string? Contrasenya { get; set; }
    }
}
