using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IMediaRepository
    {
        public Task<List<Media>> GetMedia();
        public Task<Media> GetMedia(Guid id);
        public Task<Media> GetMedia(string name);
        public Task AddMedia(Media media);
        public Task RemoveMedia(Guid id);
        public Task EditMedia(Guid id);
    }
}
