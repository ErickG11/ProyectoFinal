using System;
using System.Collections.Generic;

namespace ProyectoFinal.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Contraseña { get; set; }
}
