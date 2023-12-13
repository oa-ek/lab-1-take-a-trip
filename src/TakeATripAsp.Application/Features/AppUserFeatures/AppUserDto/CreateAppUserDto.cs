using Microsoft.AspNetCore.Http;

namespace TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto
{
    public class CreateAppUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
   
        public string Email { get; set; }

        public string Password { get; set; }

        public string? CoverPath { get; set; } = "\\img\\user\\user.jpg";

        public IFormFile? CoverFile { get; set; }

       // public string Role { get; set; }

    }
}
