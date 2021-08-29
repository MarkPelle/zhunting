using System;
using System.ComponentModel.DataAnnotations;

namespace zhunting.Data.Models
{
    public class Reservation
    {
        public Guid ID { get; set; }

        [MaxLength(100)]
        public string ReserverName { get; set; }

        [MaxLength(100)]
        public string ReserverEmail { get; set; }

        [MaxLength(100)]
        public string ReserverPhone { get; set; }

        [MaxLength(100)]
        public string ReserverCountry { get; set; }

        public int GuestNumber { get; set; }

        [MaxLength(255)]
        public string Message { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }
}
