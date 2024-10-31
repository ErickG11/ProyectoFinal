using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class GestionarUsuarios
    {

        [EmailAddress]
        public string Email { get; set; }

        public string Contraseña { get; set; }
    }
}
