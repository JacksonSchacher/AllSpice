using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recipesRepository;

    public RecipesService(RecipesRepository recipesRepository)
    {
      _recipesRepository = recipesRepository;
    }

    internal List<Recipe> GetAll()
    {
      return _recipesRepository.GetAll();
    }

    internal Recipe GetOne(int recipeId)
    {
      Recipe foundRecipe = _recipesRepository.GetOne(recipeId);
      if(foundRecipe == null) 
      {
        throw new Exception("Invalid Recipe ID");
      }
      return foundRecipe;
    }

    public Recipe CreateRecipe(Recipe recipeData)
    {
      return _recipesRepository.CreateRecipe(recipeData);
    }
  }
}