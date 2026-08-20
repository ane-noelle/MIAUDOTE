using Miaudote.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Miaudote.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Animal> Animais { get; set; }

    public DbSet<Especie> Especies { get; set; }

    public DbSet<Cidade> Cidades { get; set; }

    public DbSet<Temperamento> Temperamentos { get; set; }

    public DbSet<AnimalTemperamento> AnimaisTemperamentos { get; set; }

    public DbSet<SolicitacaoAdocao> SolicitacoesAdocao { get; set; }

    public DbSet<MensagemContato> MensagensContato { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    ConfigurarEspecie(modelBuilder);
    ConfigurarCidade(modelBuilder);
    ConfigurarTemperamento(modelBuilder);
    ConfigurarAnimal(modelBuilder);
    ConfigurarAnimalTemperamento(modelBuilder);
    ConfigurarSolicitacaoAdocao(modelBuilder);
    ConfigurarMensagemContato(modelBuilder);
    ConfigurarDadosIniciais(modelBuilder);
}

    private static void ConfigurarEspecie(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Especie>()
            .HasIndex(especie => especie.Nome)
            .IsUnique();
    }

    private static void ConfigurarCidade(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cidade>()
            .HasIndex(cidade => new
            {
                cidade.Nome,
                cidade.Uf
            })
            .IsUnique();
    }

    private static void ConfigurarTemperamento(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Temperamento>()
            .HasIndex(temperamento => temperamento.Nome)
            .IsUnique();
    }

    private static void ConfigurarAnimal(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>()
            .Property(animal => animal.Porte)
            .HasConversion<string>()
            .HasMaxLength(15);

        modelBuilder.Entity<Animal>()
            .Property(animal => animal.Genero)
            .HasConversion<string>()
            .HasMaxLength(10);

        modelBuilder.Entity<Animal>()
            .Property(animal => animal.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        modelBuilder.Entity<Animal>()
            .HasOne(animal => animal.Especie)
            .WithMany()
            .HasForeignKey(animal => animal.EspecieId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Animal>()
            .HasOne(animal => animal.Cidade)
            .WithMany()
            .HasForeignKey(animal => animal.CidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Animal>()
            .HasIndex(animal => animal.EspecieId);

        modelBuilder.Entity<Animal>()
            .HasIndex(animal => animal.CidadeId);

        modelBuilder.Entity<Animal>()
            .HasIndex(animal => animal.Status);
    }

    private static void ConfigurarAnimalTemperamento(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimalTemperamento>()
            .HasKey(animalTemperamento => new
            {
                animalTemperamento.AnimalId,
                animalTemperamento.TemperamentoId
            });

        modelBuilder.Entity<AnimalTemperamento>()
            .HasOne(animalTemperamento => animalTemperamento.Animal)
            .WithMany(animal => animal.AnimaisTemperamentos)
            .HasForeignKey(animalTemperamento =>
                animalTemperamento.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AnimalTemperamento>()
            .HasOne(animalTemperamento =>
                animalTemperamento.Temperamento)
            .WithMany(temperamento =>
                temperamento.AnimaisTemperamentos)
            .HasForeignKey(animalTemperamento =>
                animalTemperamento.TemperamentoId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigurarSolicitacaoAdocao(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SolicitacaoAdocao>()
            .Property(solicitacao => solicitacao.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        modelBuilder.Entity<SolicitacaoAdocao>()
            .HasOne(solicitacao => solicitacao.Animal)
            .WithMany(animal => animal.SolicitacoesAdocao)
            .HasForeignKey(solicitacao => solicitacao.AnimalId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SolicitacaoAdocao>()
            .HasIndex(solicitacao => solicitacao.AnimalId);

        modelBuilder.Entity<SolicitacaoAdocao>()
            .HasIndex(solicitacao => solicitacao.Status);

        modelBuilder.Entity<SolicitacaoAdocao>()
            .HasIndex(solicitacao =>
                solicitacao.DataSolicitacao);
    }

    private static void ConfigurarMensagemContato(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MensagemContato>()
            .HasIndex(mensagem => mensagem.Respondida);

        modelBuilder.Entity<MensagemContato>()
            .HasIndex(mensagem => mensagem.DataEnvio);
    }
    private static void ConfigurarDadosIniciais(
    ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Especie>().HasData(
        new Especie
        {
            Id = 1,
            Nome = "Cão",
            Ativa = true
        },
        new Especie
        {
            Id = 2,
            Nome = "Gato",
            Ativa = true
        }
    );

    modelBuilder.Entity<Cidade>().HasData(
        new Cidade
        {
            Id = 1,
            Nome = "Barra Bonita",
            Uf = "SP",
            Ativa = true
        },
        new Cidade
        {
            Id = 2,
            Nome = "São Paulo",
            Uf = "SP",
            Ativa = true
        },
        new Cidade
        {
            Id = 3,
            Nome = "Campinas",
            Uf = "SP",
            Ativa = true
        },
        new Cidade
        {
            Id = 4,
            Nome = "Rio de Janeiro",
            Uf = "RJ",
            Ativa = true
        },
        new Cidade
        {
            Id = 5,
            Nome = "Belo Horizonte",
            Uf = "MG",
            Ativa = true
        }
    );

    modelBuilder.Entity<Temperamento>().HasData(
        new Temperamento
        {
            Id = 1,
            Nome = "Calmo",
            Ativo = true
        },
        new Temperamento
        {
            Id = 2,
            Nome = "Carinhoso",
            Ativo = true
        },
        new Temperamento
        {
            Id = 3,
            Nome = "Brincalhão",
            Ativo = true
        },
        new Temperamento
        {
            Id = 4,
            Nome = "Sociável",
            Ativo = true
        },
        new Temperamento
        {
            Id = 5,
            Nome = "Energético",
            Ativo = true
        },
        new Temperamento
        {
            Id = 6,
            Nome = "Independente",
            Ativo = true
        },
        new Temperamento
        {
            Id = 7,
            Nome = "Obediente",
            Ativo = true
        },
        new Temperamento
        {
            Id = 8,
            Nome = "Protetor",
            Ativo = true
        },
        new Temperamento
        {
            Id = 9,
            Nome = "Curioso",
            Ativo = true
        }
    );
}
}