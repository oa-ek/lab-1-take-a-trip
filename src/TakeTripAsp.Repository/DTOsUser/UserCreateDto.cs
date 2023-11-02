using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Repository.DTOsUser
{
    public class UserCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public string? CoverPath { get; set; } = "\\img\\user\\user.jpg";

        public IFormFile? CoverFile { get; set; }

        public string Role { get; set; }


    }
}



   