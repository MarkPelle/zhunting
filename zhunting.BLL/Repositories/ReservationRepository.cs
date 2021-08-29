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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ZhuntingDbContext _dbContext;

        public ReservationRepository(ZhuntingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Reservation>> Get(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Reservation.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Reservation> Get(ReservationStatus status, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Reservation.AsNoTracking().SingleAsync(r => r.Status == status, cancellationToken);
        }

        public async Task<Reservation> Get(string reserver, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Reservation.AsNoTracking().SingleAsync(r => r.ReserverName == reserver, cancellationToken);
        }

        public async Task Add(Reservation reservation)
        {
            await _dbContext.Reservation.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Approve(Reservation reservation)
        {
            reservation.Status = ReservationStatus.Approved;
            _dbContext.Update(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Decline(Reservation reservation)
        {
            reservation.Status = ReservationStatus.Declined;
            _dbContext.Update(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Perform(Reservation reservation)
        {
            reservation.Status = ReservationStatus.Performed;
            _dbContext.Update(reservation);
           await _dbContext.SaveChangesAsync();
        }

        public Task<Reservation> Get(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
