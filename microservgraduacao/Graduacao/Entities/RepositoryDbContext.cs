using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using microservgraduacao.Graduacao.Entities.Aggregates.DesempenhoAggregate;
using microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate;
using microservgraduacao.Graduacao.Entities.Aggregates.EnsalamentoAggregate;
using microservgraduacao.Graduacao.Entities.Aggregates.TurmaAggregate;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace microservgraduacao.Graduacao.Entities;

public class RepositoryDbContext : DbContext
{
    private IConfiguration _configuration;
    public DbSet<Disciplina> Disciplinas {get; set;}
    public DbSet<Turma> Turmas {get; set;}
    public DbSet<Horario> Horario {get; set;}
    public DbSet<Ensalamento> Ensalamento {get; set;}
    public DbSet<DesempenhoDisciplina> Desempenho {get; set;}
    public RepositoryDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
       optionsBuilder.UseCosmos(
            connectionString: this._configuration["CosmosDBURL"],
            databaseName: this._configuration["CosmosDBDBName"],
            cosmosOptionsAction: options =>
            {
                options.ConnectionMode(ConnectionMode.Gateway);
                // options.HttpClientFactory(() => new HttpClient(new HttpClientHandler()
                // {
                //     ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                // }));
            }

        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disciplina>()
        .HasNoDiscriminator();
        modelBuilder.Entity<Disciplina>()
        .ToContainer("Disciplinas");
        modelBuilder.Entity<Disciplina>()
        .Property(p => p.Id)
        .HasValueGenerator<GuidValueGenerator>();
        modelBuilder.Entity<Disciplina>()
        .HasPartitionKey(p => p.Id);

        modelBuilder.Entity<Turma>()
        .HasNoDiscriminator();
        modelBuilder.Entity<Turma>()
        .ToContainer("Turmas");
        modelBuilder.Entity<Turma>()
        .Property(p => p.Id)
        .HasValueGenerator<GuidValueGenerator>();
        modelBuilder.Entity<Turma>()
        .HasPartitionKey(p => p.Id);      
        modelBuilder.Entity<Turma>()
        .Property(t => t.AlunosId)
        .HasConversion(
            v => string.Join(",", v),  // Converte a lista para uma string ao salvar
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList()  // Converte de volta para uma lista ao carregar
        );   

        modelBuilder.Entity<Horario>()
        .HasNoDiscriminator();
        modelBuilder.Entity<Horario>()
        .ToContainer("Horarios");
        modelBuilder.Entity<Horario>()
        .Property(p => p.Id)
        .HasValueGenerator<GuidValueGenerator>();
        modelBuilder.Entity<Horario>()
        .HasPartitionKey(p => p.Id);

        modelBuilder.Entity<Ensalamento>()
        .HasNoDiscriminator();
        modelBuilder.Entity<Ensalamento>()
        .ToContainer("Ensalamentos");
        modelBuilder.Entity<Ensalamento>()
        .Property(p => p.Id)
        .HasValueGenerator<GuidValueGenerator>();
        modelBuilder.Entity<Ensalamento>()
        .HasPartitionKey(p => p.Id);
        modelBuilder.Entity<Ensalamento>()
        .Property(e => e.Horarios)
        .HasConversion(
            v => string.Join(",", v),  // Converte a lista para uma string ao salvar
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList() // Converte de volta para uma lista ao carregar
        );

      modelBuilder.Entity<DesempenhoDisciplina>(entity =>
        {
            entity.HasNoDiscriminator();
            entity.ToContainer("Desempenhos");

            // Configuração da chave primária e partição
            entity.Property(p => p.Id)
                .HasValueGenerator<GuidValueGenerator>();
            entity.HasPartitionKey(p => p.Id);

            // Mapeamento de propriedades complexas
            entity.OwnsOne(p => p.Nota);
            entity.OwnsOne(p => p.NotaExame);
            entity.OwnsOne(p => p.Frequencia);
            entity.OwnsOne(p => p.StatusAluno);
        });
                
    
    }


}
