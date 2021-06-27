﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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