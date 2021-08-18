using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        public Task<Reservation> Get(ReservationStatus status, CancellationToken cancellationToken);
        public Task Decline(Reservation reservation);
        public Task Approve(Reservation reservation);
        public Task Perform(Reservation reservation);
    }
}
