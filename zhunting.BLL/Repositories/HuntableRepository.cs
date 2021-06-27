using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task AddHuntable(Huntable huntable)
        {
            throw new NotImplementedException();
        }

        public Task EditHuntable(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Huntable>> GetHuntable()
        {
            return await _dbContext.Huntable.AsNoTracking().ToListAsync();
        }

        public async Task<Huntable> GetHuntable(Guid id)
        {
            return await _dbContext.Huntable.AsNoTracking().SingleAsync(h => h.ID == id);
        }

        public async Task<Huntable> GetHuntable(string name)
        {
            return await _dbContext.Huntable.AsNoTracking().SingleAsync(h => h.Name == name);
        }

        public Task RemoveHuntable(Huntable huntable)
        {
            throw new NotImplementedException();
        }
    }
}
