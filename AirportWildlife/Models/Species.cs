﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWildlife.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Interaction> Interactions { get; set; }
    }
}
