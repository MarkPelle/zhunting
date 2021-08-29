using System;
using System.ComponentModel.DataAnnotations;

namespace zhunting.Data.Models
{
    public class Image
    {
        public Guid ID { get; set; }

        [MaxLength(125)]
        public string Url { get; set; }
        public Media Media { get; set; }
    }
}