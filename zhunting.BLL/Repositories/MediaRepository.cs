using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
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

        public async Task<List<Media>> Get(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Media.ToListAsync(cancellationToken);
        }

        public async Task<Media> Get(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Media.AsNoTracking().Include(i => i.Images).SingleOrDefaultAsync(m => m.ID == id, cancellationToken);
        }

        public async Task<Media> Get(string name, CancellationToken cancellationToken)
        {
            return await _dbContext.Media.AsNoTracking().Include(i => i.Images).FirstOrDefaultAsync(m => m.Name == name, cancellationToken);
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
