using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using zhunting.Data.Models;
using zhunting.DataAccess.Repositories;

namespace zhunting.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<List<Reservation>> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _reservationRepository.GetReservation();
            }
            catch (OperationCanceledException)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return null;
            }
        }

        [HttpPost]
        public async Task Create([FromBody] Reservation reservation)
        {
            await _reservationRepository.AddReservation(reservation);
        }

        [HttpPost("approve")]
        public async Task ApproveReservation([FromBody] Reservation reservation)
        {
            await _reservationRepository.ApproveReservation(reservation);
        }

        [HttpPost("decline")]
        public async Task DeclineReservation([FromBody] Reservation reservation)
        {
            await _reservationRepository.DeclineReservation(reservation);
        }

        [HttpPost("perform")]
        public async Task PerformReservation([FromBody] Reservation reservation)
        {
            await _reservationRepository.PerformReservation(reservation);
        }

    }
}
