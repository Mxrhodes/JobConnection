using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobConnection.Models
{
    public class Professional
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 9)]
        public string EIN { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public bool isBusinessOwner { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        [Range(5, 50, ErrorMessage = "You must at least have 5 years of experience in your profession.")]
        [Display(Name = "Years Of Experience")]
        public int YearsOfExperience { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}