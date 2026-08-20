using Miaudote.Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conexaoBanco = builder.Configuration
    .GetConnectionString("ConexaoPadrao");

if (string.IsNullOrWhiteSpace(conexaoBanco))
{
    throw new InvalidOperationException(
        "A string de conexão 'ConexaoPadrao' não foi configurada."
    );
}

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        conexaoBanco,
        ServerVersion.AutoDetect(conexaoBanco)
    );
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();