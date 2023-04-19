using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizzas([FromQuery] string? nome)
        {
            using var ctx = new PizzeriaContext();

            var pizzas = ctx.Pizzas.Where(p => nome == null || p.Nome.ToLower().Contains(nome.ToLower())).ToList();

            return Ok(pizzas);
        }

        [HttpGet("{id}")]
        public IActionResult GetPizzas(int id)
        {
            using var ctx = new PizzeriaContext();

            var pizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

            if(pizza is null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }
    }
}
