using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirportWildlife.Models
{
    public class Interaction
    {
        [Key]
        public int InteractionId { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int SpeciesCount { get; set; }
        [Required]
        public int NumberTaken { get; set; }
        [Required]
        public DateTime DateTime {get; set;}
        public string Comments { get; set; }
        [Required]
        public int SpeciesId { get; set; }
        [Required]
        public Species Species { get; set; }
        [Required]
        public int AnimalActivityId { get; set; }
        [Required]
        public AnimalActivity AnimalActivity { get; set; }
        [Required]
        public int HabitatId { get; set; }
        [Required]
        public Habitat Habitat { get; set; }
        [Required]
        public int ControlMethodId { get; set; }
        [Required]
        public ControlMethod ControlMethod { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public Employee Employee { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
