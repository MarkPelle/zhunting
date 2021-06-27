using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IHuntableRepository
    {
        public Task<List<Huntable>> GetHuntable();
        public Task<Huntable> GetHuntable(Guid id);
        public Task<Huntable> GetHuntable(string name);
        public Task AddHuntable(Huntable huntable);
        public Task RemoveHuntable(Guid id);
        public Task EditHuntable(Huntable huntable);
    }
}
