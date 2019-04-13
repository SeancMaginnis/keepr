using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Name { get; set; }
    public int UserId { get; set; }

  }
}