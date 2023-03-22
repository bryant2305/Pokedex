using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext>options): base(options) { }

        public DbSet<ProductPokemon> productPokemons { get; set; }

        public DbSet<ProductRegion> Regiones { get; set; }

        public DbSet<ProductTipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // este es el fluent Api

            #region tables
            modelBuilder.Entity<ProductPokemon>().ToTable("Pokemon");
            modelBuilder.Entity<ProductRegion>().ToTable("Regiones");
            modelBuilder.Entity<ProductTipo>().ToTable("Types");
            #endregion

            #region "primary keys"

            modelBuilder.Entity<ProductPokemon>().HasKey(productPokemon => productPokemon.Id);
            modelBuilder.Entity<ProductRegion>().HasKey(Region => Region.Id);
            modelBuilder.Entity<ProductTipo>().HasKey(Tipo => Tipo.Id);

            #endregion

            #region "RelationShips"

            modelBuilder.Entity<ProductRegion>().HasMany<ProductPokemon>(Region => Region.ProductPokemon)
                            .WithOne(ProductPokemon => ProductPokemon.Region).HasForeignKey(ProductPokemon => ProductPokemon.RegionId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductTipo>().HasMany<ProductPokemon>(Tipo => Tipo.ProductPokemon)
                .WithOne(ProductPokemon => ProductPokemon.Tipo).HasForeignKey(ProductPokemon => ProductPokemon.TipoId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductTipo>().HasMany<ProductPokemon>(Tipo => Tipo.ProductPokemon)
                .WithOne(ProductPokemon => ProductPokemon.Tipo).HasForeignKey(ProductPokemon => ProductPokemon.TipoIdSec).OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Property configurations"


            modelBuilder.Entity<ProductTipo>().Property(Tipo => Tipo.Name).IsRequired();

            modelBuilder.Entity<ProductRegion>().Property(Region => Region.Name).IsRequired();

            modelBuilder.Entity<ProductPokemon>().Property(Pokemon => Pokemon.Name).IsRequired();
            modelBuilder.Entity<ProductPokemon>().Property(Pokemon => Pokemon.ImageUrl).IsRequired();
            modelBuilder.Entity<ProductPokemon>().Property(Pokemon => Pokemon.RegionId).IsRequired();
            modelBuilder.Entity<ProductPokemon>().Property(Pokemon => Pokemon.TipoId).IsRequired();
            #endregion






        }
    }
}
