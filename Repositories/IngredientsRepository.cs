using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class IngredientsRepository
  {
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Ingredient> GetAll()
    {
      string sql = "SELECT * FROM ingredients;";
      return _db.Query<Ingredient>(sql).ToList();
    }

    internal Ingredient GetOne(int ingredientId)
    {
      string sql = "SELECT * FROM ingredients WHERE id = @ingredientId;";
      return _db.QueryFirstOrDefault<Ingredient>(sql, new {ingredientId});
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      string sql = @"
      INSERT INTO ingredients(IngredientName)
      VALUES (@IngredientName);
      SELECT LAST_INSERT_ID();
      ";;
      int id = _db.ExecuteScalar<int>(sql, ingredientData);
      ingredientData.Id = id;
      return ingredientData;
    }
  }
}