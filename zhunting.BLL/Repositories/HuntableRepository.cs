using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess;
using zhunting.DataAccess.Repositories;

namespace zhunting.BLL.Repositories
{
    public class HuntableRepository : IHuntableRepository
    {
        private readonly ZhuntingDbContext _dbContext;

        public HuntableRepository(ZhuntingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Huntable>> GetHuntable()
        {
            return await _dbContext.Huntable.AsNoTracking().Include(h => h.Image).ToListAsync();
        }

        public async Task<Huntable> GetHuntable(Guid id)
        {
            return await _dbContext.Huntable.AsNoTracking().SingleAsync(h => h.ID == id);
        }

        public async Task<Huntable> GetHuntable(string name)
        {
            return await _dbContext.Huntable.AsNoTracking().SingleAsync(h => h.Name == name);
        }

        public async Task AddHuntable(Huntable huntable)
        {
            await _dbContext.AddAsync(huntable);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveHuntable(Guid id)
        {
            var getHuntable = await GetHuntable(id);
            _dbContext.Remove(getHuntable);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditHuntable(Huntable huntable)
        {
            _dbContext.Update(huntable);
            await _dbContext.SaveChangesAsync();
        }
    }
}
