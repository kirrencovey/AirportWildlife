using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWildlife.Models
{
    public class Habitat
    {
        [Key]
        public int HabitatId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Interaction> Interactions { get; set; }
    }
}
