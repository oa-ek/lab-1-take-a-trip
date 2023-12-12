﻿using Microsoft.AspNetCore.Http;

namespace TakeTripAsp.Application.Features.AppUserFeatures.AppUserDto
{
    public class ReadAppUserDto
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