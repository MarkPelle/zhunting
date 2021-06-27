using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
