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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ZhuntingDbContext _dbContext;

        public ReservationRepository(ZhuntingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AcceptReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task AddReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task DeclineReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Reservation>> GetReservation()
        {
            return await _dbContext.Reservation.AsNoTracking().ToListAsync();
        }

        public async Task<Reservation> GetReservation(string reserver)
        {
            return await _dbContext.Reservation.AsNoTracking().SingleAsync(r => r.ReserverName == reserver);
        }

        public async Task<Reservation> GetReservation(ReservationStatus status)
        {
            return await _dbContext.Reservation.AsNoTracking().SingleAsync(r => r.Status == status);
        }

        public Task PerformReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
