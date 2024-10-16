using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using microservgraduacao.Graduacao.Entities.Aggregates.DisciplinaAggregate;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace microservgraduacao.Graduacao.Entities;

public class RepositoryDbContext : DbContext
{
    private IConfiguration _configuration;
    public DbSet<Disciplina> Disciplinas {get; set;}
    public RepositoryDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseCosmos(
            connectionString: this._configuration["CosmosDBURL"],
            databaseName: this._configuration["CosmosDBDBName"]
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
    
    }
}
