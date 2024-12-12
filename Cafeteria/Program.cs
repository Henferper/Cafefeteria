using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cafeteria.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Configuração de culturas suportadas
var supportedCultures = new[] { "en-US", "pt-BR" };
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
    SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
};

// Adicionar serviços MVC com suporte à localização
builder.Services.AddControllersWithViews()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

// Configuração do banco de dados
builder.Services.AddDbContext<CafeteriaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CafeteriaContext") ?? 
                      throw new InvalidOperationException("Connection string 'CafeteriaContext' not found.")));

// Criar o aplicativo
var app = builder.Build();

// Configuração do pipeline de requisição
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Configurar localização
app.UseRequestLocalization(localizationOptions);

app.UseRouting();
app.UseAuthorization();

// Definir as rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Rodar o aplicativo
app.Run();
