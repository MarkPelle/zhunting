using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhunting.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        public Task<List<T>> Get();
        public Task<T> Get(Guid id);
        public Task<T> Get(string name);
        public Task Add(T entity);
        public Task Remove(Guid id);
        public Task Edit(T entity);

    }
}
