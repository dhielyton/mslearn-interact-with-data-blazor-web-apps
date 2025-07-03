using BlazingPizza.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Controllers
{
    [Route("special")]
    [ApiController]
    public class SpecialController : Controller
    {
        private readonly PizzaService _pizzaService;
        public SpecialController(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<List<PizzaSpecial>> Get()
        {
            return await _pizzaService.GetAsync();
        }
        
    }
}
