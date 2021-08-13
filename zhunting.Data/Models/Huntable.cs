using System;
using System.ComponentModel.DataAnnotations;

namespace zhunting.Data.Models
{
    public class Huntable
    {
        public Guid ID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public Zone Zone { get; set; }

        public double Price { get; set; }

        public Image Image { get; set; }
    }
}
