using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Servicios.Contrato;
using ProyectoFinal.Servicios.Implementacion;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbloginContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configurar autenticaci�n con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion"; // Ruta de inicio de sesi�n
        options.AccessDeniedPath = "/Home/AccessDenied"; // Ruta para acceso denegado si la necesitas
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Tiempo de expiraci�n de la sesi�n
    });

// Configuraci�n para evitar cach� en las vistas
builder.Services.AddControllersWithViews(options => {
    options.Filters.Add(new ResponseCacheAttribute
    {
        NoStore = true,
        Location = ResponseCacheLocation.None,
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Habilitar autenticaci�n
app.UseAuthorization();

// Configuraci�n del enrutamiento de controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Iniciar en Home/Index

app.Run();
