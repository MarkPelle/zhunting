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
    public class MediaRepository : IMediaRepository
    {

        private readonly ZhuntingDbContext _dbContext;

        public MediaRepository(ZhuntingDbContext dbcContext)
        {
            _dbContext = dbcContext;
        }

        public async Task<List<Media>> GetMedia()
        {
            return await _dbContext.Media.ToListAsync();
        }

        public async Task<Media> GetMedia(Guid id)
        {
            return await _dbContext.Media.AsNoTracking().SingleOrDefaultAsync(m => m.ID == id);
        }

        public async Task<Media> GetMedia(string name)
        {
            return await _dbContext.Media.AsNoTracking().FirstOrDefaultAsync(m => m.Name == name);
        }

        public async Task AddMedia(Media media)
        {
            await _dbContext.AddAsync(media);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveMedia(Guid id)
        {
            var media = await GetMedia(id);
            _dbContext.Media.Remove(media);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditMedia(Media media)
        {
            _dbContext.Update(media);
            await _dbContext.SaveChangesAsync();
        }
    }
}
