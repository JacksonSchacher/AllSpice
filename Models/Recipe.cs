using System.ComponentModel.DataAnnotations;

namespace AllSpice.Models
{
  public class Recipe 
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    [Required]
    public string Name { get; set; }
    public Profile Creator { get; set; }
  }
}