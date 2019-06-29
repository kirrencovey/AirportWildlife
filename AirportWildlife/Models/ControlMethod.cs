using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWildlife.Models
{
    public class ControlMethod
    {
        [Key]
        public int ControlMethodId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Interaction> Interactions { get; set; }
    }
}
