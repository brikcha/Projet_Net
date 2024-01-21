using Microsoft.EntityFrameworkCore;
using SW.DataAccessLayer;
using SW.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajout du DBContext par injection de d�pendance.
builder.Services.AddDbContext<StarWarsDBContext>(options =>
{
    // On pr�cise au DBContexte qu'il devra utiliser SQLite et
    // se baser sur la chaine de connexion "SW" disponible dans le appsettings.json
    options.UseSqlite(builder.Configuration.GetConnectionString("SW"));
});
// Injection de d�pendance du CitoyenRepository
builder.Services.AddScoped<CitoyenRepository>();
// Injection de d�pendance du DivisionCitoyen
builder.Services.AddScoped<DivisionCitoyen>();

builder.Services.AddScoped<EspeceRepository>();
builder.Services.AddScoped<EspeceService>();
// ajouter indicateurs
//builder.Services.AddScoped<IndicateurService>();
builder.Services.AddSingleton<IndicateurService>();




builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "indicateur",
    pattern: "Indicateur/{action=Index}/{id?}",
    defaults: new { controller = "Indicateur" });


app.Run();
