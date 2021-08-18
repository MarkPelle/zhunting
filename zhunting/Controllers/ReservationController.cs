using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<List<Reservation>> Get(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _reservationRepository.Get(cancellationToken);
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
            await _reservationRepository.Add(reservation);
        }

        [Authorize]
        [HttpPost("approve")]
        public async Task ApproveReservation([FromBody] Reservation reservation)
        {
            await _reservationRepository.Approve(reservation);
        }

        [Authorize]
        [HttpPost("decline")]
        public async Task DeclineReservation([FromBody] Reservation reservation)
        {
            await _reservationRepository.Decline(reservation);
        }

        [Authorize]
        [HttpPost("perform")]
        public async Task PerformReservation([FromBody] Reservation reservation)
        {
            await _reservationRepository.Perform(reservation);
        }

    }
}
