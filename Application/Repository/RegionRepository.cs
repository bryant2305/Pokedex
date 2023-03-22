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
    public class RegionRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(ProductRegion region)
        {
            await _dbContext.Regiones.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(ProductRegion region)
        {
            _dbContext.Entry(region).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(ProductRegion region)
        {
            _dbContext.Set<ProductRegion>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ProductRegion>> GetAllRegionAsync()
        {
            return await _dbContext.Set<ProductRegion>().ToListAsync();
        }

        public async Task<ProductRegion> GetByIdRegionAsync(int Id)
        {
            return await _dbContext.Set<ProductRegion>().FindAsync(Id);
        }

       
    }
}
