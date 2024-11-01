using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Servicios.Contrato;

namespace ProyectoFinal.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly DbloginContext _dbContext;
        public UsuarioService(DbloginContext dbContext) //Constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string contraseña)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Contraseña == contraseña)
                .FirstOrDefaultAsync();
            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
