using Microsoft.EntityFrameworkCore.Query.Internal;
using ProyectoFinal.Models;

namespace ProyectoFinal.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave); //Devolver Usuario
        Task<Usuario> SaveUsuario(Usuario modelo); //Guarda Usuario
    }
}
