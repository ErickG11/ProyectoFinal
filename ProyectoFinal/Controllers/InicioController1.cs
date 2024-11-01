using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Recursos;
using ProyectoFinal.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies; //Para utilizar la autenticación por cookies
using Microsoft.AspNetCore.Authentication;

namespace ProyectoFinal.Controllers
{
    public class InicioController1 : Controller
    {

        private readonly IUsuarioService _usuarioServicio;

        public InicioController1(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio; 
        }


        public IActionResult Registrarse() //Tipo get, devuelve la vista
        {
            return View();
        }

        [HttpPost]
        public async IActionResult Registrarse(Usuario modelo) //Responder la solicitud de la vista de arriba
        {
            modelo.Contraseña = Utilidades.EncriptarContraseña(modelo.Contraseña);

            Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion()
        {
            return View();
        }
    }
}
