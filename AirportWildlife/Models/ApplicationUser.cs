using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AirportWildlife.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Required]
        [Display(Name = "Airport")]
        public string Airport { get; set; }

        public virtual ICollection<AnimalActivity> AnimalActivities { get; set; }
        public virtual ICollection<ControlMethod> ControlMethods { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Habitat> Habitats { get; set; }
        public virtual ICollection<Interaction> Interactions { get; set; }
        public virtual ICollection<Species> Species { get; set; }
    }
}