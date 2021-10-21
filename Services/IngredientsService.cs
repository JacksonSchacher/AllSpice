using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class IngredientsService 
  {
    private readonly IngredientsRepository _ingredientsRepository;

    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
      _ingredientsRepository = ingredientsRepository;
    }

    internal List<Ingredient> GetAll()
    {
      return _ingredientsRepository.GetAll();
    }

    internal Ingredient GetOne(int ingredientId)
    {
      return _ingredientsRepository.GetOne(ingredientId);
    }

    internal Ingredient Create(Ingredient ingredientData)
    {
      return _ingredientsRepository.Create(ingredientData);
    }
  }
}