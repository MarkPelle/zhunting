using System;
using System.ComponentModel.DataAnnotations;

namespace zhunting.Data.Models
{
    public class Staff
    {
        public Guid ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public Title Title { get; set; }
    }
}
