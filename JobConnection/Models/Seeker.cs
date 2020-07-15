using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobConnection.Models
{
    public class Seeker
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }


        public Occupation Occupation { get; set; }

        [ForeignKey("Occupation")]
        public int OccupationId { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string JobTitle { get; set; }

        [Required]
        [Range(0, 70, ErrorMessage = "Years of experience must not exceed 70.")]
        [Display(Name = "Years Of Experience")]
        public int YearsOfExperience { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]

        // Learn from Skilled Professionals or Business Owners
        public string IntendedUse { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}