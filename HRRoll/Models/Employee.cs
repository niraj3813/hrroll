using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRRoll.Data; // For AppUser

namespace HRRoll.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Department { get; set; }

        public decimal Salary { get; set; }

        // Foreign key to AppUser
        public string? AppUserId { get; set; } // Foreign key to AspNetUsers.Id
        public AppUser? AppUser { get; set; }  // Navigation property

        public int? ClientMasterId { get; set; }

        [ForeignKey("ClientMasterId")]
        public ClientMaster? ClientMaster { get; set; }

        public string Email { get; set; }
        public string SSN { get; set; }

        // Computed property for safe last 4 SSN display
        [NotMapped]
        public string Last4SSN
        {
            get
            {
                if (string.IsNullOrWhiteSpace(SSN) || SSN.Length < 4)
                    return string.Empty;
                return SSN.Substring(SSN.Length - 4);
            }
        }
    }
}
