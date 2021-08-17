using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess;
using zhunting.DataAccess.Repositories;

namespace zhunting.BLL.Repositories
{
    public class MediaRepository : IMediaRepository
    {

        private readonly ZhuntingDbContext _dbContext;

        public MediaRepository(ZhuntingDbContext dbcContext)
        {
            _dbContext = dbcContext;
        }

        public async Task<List<Media>> Get()
        {
            return await _dbContext.Media.ToListAsync();
        }

        public async Task<Media> Get(Guid id)
        {
            return await _dbContext.Media.AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);
        }

        public async Task<Media> Get(string name)
        {
            return await _dbContext.Media.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task Add(Media media)
        {
            await _dbContext.AddAsync(media);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var media = await Get(id);
            _dbContext.Media.Remove(media);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Edit(Media media)
        {
            _dbContext.Update(media);
            await _dbContext.SaveChangesAsync();
        }
    }
}
