using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zhunting.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        public Task<List<T>> Get(CancellationToken cancellationToken);
        public Task<T> Get(Guid id, CancellationToken cancellationToken);
        public Task<T> Get(string name, CancellationToken cancellationToken);
        public Task Add(T entity);
        public Task Remove(Guid id);
        public Task Edit(T entity);

    }
}
