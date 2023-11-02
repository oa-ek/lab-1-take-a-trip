using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTripAsp.Repository.DTOsUser
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? CoverPath { get; set; } = "\\img\\user\\user.jpg";

        public IFormFile? CoverFile { get; set; }

        public List<string> Role { get; set; }
        public bool IsConfirmed { get; set; }
    }
}


﻿


   
