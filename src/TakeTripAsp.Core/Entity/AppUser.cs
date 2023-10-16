using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakeTripAsp.Core.Entity
{
    public class AppUser : IdentityUser
    {
        public  string? FirstName { get; set; }
        public string? LastName { get; set; }
        public  string? Email { get; set; }
       // public required string Bio { get; set; }
        //public string? CoverPath { get; set; } = "\\img\\user\\user.jpg";

       // [NotMapped]
       // public IFormFile? CoverFile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual ICollection<SelectedTour>? Tours { get; set; }
    }
}
