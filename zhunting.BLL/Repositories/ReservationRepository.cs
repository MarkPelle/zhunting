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

        public async Task ApproveReservation(Reservation reservation)
        {
            reservation.Status = ReservationStatus.Approved;
            _dbContext.Update(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddReservation(Reservation reservation)
        {
            await _dbContext.Reservation.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeclineReservation(Reservation reservation)
        {
            reservation.Status = ReservationStatus.Declined;
            _dbContext.Update(reservation);
            await _dbContext.SaveChangesAsync();
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

        public async Task PerformReservation(Reservation reservation)
        {
            reservation.Status = ReservationStatus.Performed;
            _dbContext.Update(reservation);
           await _dbContext.SaveChangesAsync();
        }
    }
}
