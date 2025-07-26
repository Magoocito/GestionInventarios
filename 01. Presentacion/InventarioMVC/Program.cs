using AutoMapper;
using GestionInventarios.Aplicacion.Persistencia;
using GestionInventarios.Infraestructura.Mapper;
using GestionInventarios.Infraestructura.Persistencia.AdoConexion;
using GestionInventarios.Infraestructura.Persistencia.AdoContexto;
using GestionInventarios.Infraestructura.Persistencia.UnitOfWork;
using GestionInventarios.Infraestructura.Servicios;
using GestionInventarios.Web.Configuraciones;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseDependencyInjectorConfiguration(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperProfile));


builder.Services.AddScoped<AdoConfig>(sp =>
    new AdoConfig { ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty });

builder.Services.AddScoped<SqlConnection>(sp =>
{
    var config = sp.GetRequiredService<AdoConfig>();
    var connection = new SqlConnection(config.ConnectionString);
    connection.Open();
    return connection;
});

builder.Services.AddScoped<SqlTransaction>(sp =>
{
    var connection = sp.GetRequiredService<SqlConnection>();
    return connection.BeginTransaction();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
