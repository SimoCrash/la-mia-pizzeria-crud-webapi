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

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza)
        {
            using var ctx = new PizzeriaContext();

            ctx.Pizzas.Add(pizza);

            ctx.SaveChanges();

            return Ok(pizza);
        }

        [HttpPut("{id}")]
        public IActionResult PutPizza(int id, [FromBody] Pizza pizza)
        {
            using var ctx = new PizzeriaContext();

            var savedPizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

            if (savedPizza is null)
            {
                return NotFound();
            }

            savedPizza.Nome = pizza.Nome;
            savedPizza.Descrizione = pizza.Descrizione;
            savedPizza.CategoriaId = pizza.CategoriaId;
            savedPizza.Prezzo = pizza.Prezzo;

            ctx.SaveChanges();

            return Ok(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            using var ctx = new PizzeriaContext();

            var savedPizza = ctx.Pizzas.FirstOrDefault(p => p.Id == id);

            if (savedPizza is null)
            {
                return NotFound();
            }

            ctx.Pizzas.Remove(savedPizza);

            ctx.SaveChanges();

            return Ok();
        }
    }
}
