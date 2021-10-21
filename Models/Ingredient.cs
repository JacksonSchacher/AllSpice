using System.ComponentModel.DataAnnotations;

namespace AllSpice.Models
{
  public class Ingredient 
  {
    public int Id { get; set; }
    [Required]
    public string IngredientName { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
  }
}