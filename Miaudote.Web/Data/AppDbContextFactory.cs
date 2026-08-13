using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Miaudote.Web.Data;

public class AppDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var configuracao = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                "appsettings.json",
                optional: false
            )
            .AddJsonFile(
                "appsettings.Development.json",
                optional: false
            )
            .Build();

        var conexaoBanco = configuracao
            .GetConnectionString("ConexaoPadrao");

        if (string.IsNullOrWhiteSpace(conexaoBanco))
        {
            throw new InvalidOperationException(
                "A string de conexão ConexaoPadrao não foi configurada."
            );
        }

        var optionsBuilder =
            new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseMySql(
            conexaoBanco,
            ServerVersion.AutoDetect(conexaoBanco)
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}