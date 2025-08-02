using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace HRRoll.Data
{
    public class AppUser : IdentityUser
    {
        [StringLength(9)]
        public string SSN { get; set; }
        public string? EmailVerificationCode { get; set; }
        public DateTime? CodeGeneratedAt { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public int? ClientMasterId { get; set; }
        public ClientMaster? ClientMaster { get; set; }

        

    }
}
