using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace TakeTripAsp.Core.Entity
{
    public class Profile : BaseEntity
    {
        public int UserId { get; set; }

        public AppUser? User { get; set; }

        public string? CoverPath { get; set; } = "\\img\\profile\\profile.jpg";

        [NotMapped]
        public IFormFile? CoverFile { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
