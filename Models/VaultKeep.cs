using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int VaultId { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int KeepId { get; set; }
  }
}