using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class RecipesRepository 
  {
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Recipe> GetAll()
    {
      string sql = "SELECT * FROM recipes;";
      return _db.Query<Recipe>(sql).ToList();
    }

    internal Recipe GetOne(int recipeId)
    {
      string sql = @"
      SELECT 
      r.*,
      a.* 
      FROM recipes r
      JOIN accounts a on r.creatorId = a.id
      WHERE r.id = @recipeId;";
      return _db.Query<Recipe, Account, Recipe>(sql, (r, a) => 
      {
        r.Creator = a;
        return r;
      }, new {recipeId}).FirstOrDefault();
    }

    public Recipe CreateRecipe(Recipe recipeData)
    {
      string sql = @"
      INSERT INTO recipes(creatorId, name)
      VALUES(@CreatorId, @Name);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, recipeData);
      recipeData.Id = id;
      return recipeData;
    }
  }
}