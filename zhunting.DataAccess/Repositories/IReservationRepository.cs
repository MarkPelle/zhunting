using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhunting.Data.Models;

namespace zhunting.DataAccess.Repositories
{
    public interface IReservationRepository
    {
        public Task<List<Reservation>> GetReservation();
        public Task<Reservation> GetReservation(string reserver);
        public Task<Reservation> GetReservation(ReservationStatus status);
        public Task AddReservation(Reservation reservation);
        public Task DeclineReservation(Reservation reservation);
        public Task AcceptReservation(Reservation reservation);
        public Task PerformReservation(Reservation reservation);
    }
}
