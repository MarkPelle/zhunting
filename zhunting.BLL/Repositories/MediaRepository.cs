using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories;

namespace zhunting.BLL.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        public Task AddMedia(Media media)
        {
            throw new NotImplementedException();
        }

        public Task EditMedia(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Media>> GetMedia()
        {
            throw new NotImplementedException();
        }

        public Task<Media> GetMedia(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Media> GetMedia(string name)
        {
            throw new NotImplementedException();
        }

        public Task RemoveMedia(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
