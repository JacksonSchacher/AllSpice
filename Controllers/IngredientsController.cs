using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientsService;

    public IngredientsController(IngredientsService ingredientsService)
    {
      _ingredientsService = ingredientsService;
    }

    [HttpGet]

    public ActionResult<List<Ingredient>> GetAll()
    {
      try
      {
           return Ok(_ingredientsService.GetAll());
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    [HttpGet("{IngredientId}")]
    public ActionResult<Ingredient> GetOne(int ingredientId)
    {
      try
      {
           return Ok(_ingredientsService.GetOne(ingredientId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Ingredient> Create([FromBody] Ingredient ingredientData){
      try
      {
        Ingredient createdIngredient = _ingredientsService.Create(ingredientData);
        return createdIngredient;
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
