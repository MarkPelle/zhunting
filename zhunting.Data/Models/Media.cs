using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zhunting.Data.Models
{
    public class Media
    {
        public Guid ID { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }
        public List<Image> Images { get; set; }
    }
}
