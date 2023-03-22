using Database.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TipoRepository
    {
        private ApplicationContext _dbContext;

        public TipoRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProductTipo tipo)
        {
            await _dbContext.Tipos.AddAsync(tipo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(ProductTipo tipo)
        {
            _dbContext.Entry(tipo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ProductTipo tipo)
        {
            _dbContext.Set<ProductTipo>().Remove(tipo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ProductTipo>> GetAllTiposAsync()
        {
            return await _dbContext.Set<ProductTipo>().ToListAsync();
        }

        public async Task<ProductTipo> GetByIdTipoAsync(int Id)
        {
            return await _dbContext.Set<ProductTipo>().FindAsync(Id);
        }
    }
}
