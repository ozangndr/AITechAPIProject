using AITech.DataAccess.Context;
using AITech.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.DataAccess.Repositories.GenericRapository
{
    public class GenericRepository<TEntity>(AppDbContext _context) : IRepository<TEntity> where TEntity : BaseEntity
    {
        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            
        }       

        public void Delete(TEntity entity)
        {            
            _context.Remove(entity);            
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public  void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
