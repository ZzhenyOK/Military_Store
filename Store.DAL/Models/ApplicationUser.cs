using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
