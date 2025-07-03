using BlazingPizza.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Controllers
{
    [Route("specials")]
    [ApiController]
    public class SpecialsController : Controller
    {
        private readonly PizzaService _pizzaService;
        public SpecialsController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
        {
            return await _pizzaService.GetAsync();
            
        }
        
    }
}
