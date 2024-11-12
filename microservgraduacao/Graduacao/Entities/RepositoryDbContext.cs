using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate;
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
                options.HttpClientFactory(() => new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                }));
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
    
    }


}
