

using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string UserId { get; set; }
    public int IsPrivate { get; set; }
    [Required]
    public int Views { get; set; }
    [Required]
    public int Shares { get; set; }
    public int Keeps { get; set; }


    [Required]
    public string Img { get; set; }




  }
}