using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    [Authorize]
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        
        
    }
}
