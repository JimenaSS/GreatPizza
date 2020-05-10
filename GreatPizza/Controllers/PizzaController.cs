using System;
using System.Collections.Generic;
using GreatPizza.Contracts;
using GreatPizza.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace GreatPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private IPizzaService pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        // GET api/pizza
        [HttpGet]
        public ActionResult<List<Pizza>> Get()
        {
            try
            {
                return pizzaService.GetAll();
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }

        // GET api/pizza/[name]
        [HttpGet("{name}")]
        public ActionResult<Pizza> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new ObjectResult(new { Status = 400, Value = "Pizza name is needed" });

            try
            {
                return pizzaService.GetByName(name);
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }

        // POST api/pizza
        [HttpPost]
        public IActionResult Post([FromBody] Pizza pizza)
        {
            if (string.IsNullOrEmpty(pizza.Name))
                return new ObjectResult(new { Status = 400, Value = "Pizza name can't be empty" });

            try
            {
                pizzaService.Add(pizza);
                return new ObjectResult(new { Status = 200, Value = string.Format("Pizza {0} created", pizza.Name) });
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }

        // DELETE api/pizza/[name]
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new ObjectResult(new { Status = 400, Value = "Pizza name can't be empty" });

            try
            {
                pizzaService.Delete(new Pizza() { Name = name });
                return new ObjectResult(new { Status = 200, Value = string.Format("Pizza {0} deleted", name) });
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }
    }
}
