using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }

    public string UserId { get; set; }
    [Required]

    public int VaultId { get; set; }
    [Required]

    public int KeepId { get; set; }
  }
}