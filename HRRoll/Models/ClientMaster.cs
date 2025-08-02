using HRRoll.Data;
using HRRoll.Models;
using System.ComponentModel.DataAnnotations;

public class ClientMaster
{
    [Key]
    public int ClientMasterId { get; set; }

    [Required]
    public string MasterCode { get; set; } = string.Empty;

    [Required]
    public string ClientCode { get; set; } = string.Empty;

    [Required]
    public string ClientName { get; set; }

    public ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
