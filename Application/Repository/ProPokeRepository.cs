using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ProPokeRepository
    {
        private readonly ApplicationContext _dbContext;

        public ProPokeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateAsync(ProductPokemon productPokemon)
        {
            _dbContext.Entry(productPokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddAsync(ProductPokemon productPokemon)
        {
            await _dbContext.productPokemons.AddAsync(productPokemon);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ProductPokemon productPokemon)
        {
            _dbContext.Set<ProductPokemon>().Remove(productPokemon);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ProductPokemon>> GetAllAsync()
        {
            return await _dbContext.Set<ProductPokemon>().ToListAsync();
        }
        public async Task<ProductPokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<ProductPokemon>().FindAsync(id);
        }
    }
}
