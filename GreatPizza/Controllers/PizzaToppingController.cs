using System;
using System.Collections.Generic;
using GreatPizza.Contracts;
using GreatPizza.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace GreatPizza.Controllers
{
    [Route("api/pizza/{name}/topping")]
    [ApiController]
    public class PizzaToppingController : ControllerBase
    {
        private IPizzaToppingService pizzaToppingService;

        public PizzaToppingController(IPizzaToppingService pizzaService)
        {
            this.pizzaToppingService = pizzaService;
        }

        // GET api/pizza/[name]/topping
        [HttpGet]
        public ActionResult<List<Topping>> Get(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new ObjectResult(new { Status = 400, Value = "Pizza name can't be empty" });

            try
            {
                return pizzaToppingService.GetPizzaToppings(new Pizza() { Name = name });
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }

        // POST api/pizza/[name]/topping
        [HttpPost]
        public ActionResult<Pizza> Post(string name, [FromBody] List<Topping> toppings)
        {
            if (string.IsNullOrEmpty(name))
                return new ObjectResult(new { Status = 400, Value = "Pizza name can't be empty" });

            var pizza = new Pizza() { Name = name };

            try
            {
                return pizzaToppingService.AddToppings(pizza, toppings);
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }

        // DELETE api/pizza/[name]/topping
        [HttpDelete]
        public ActionResult<Pizza> Delete(string name, [FromBody] List<Topping> toppings)
        {
            if (string.IsNullOrEmpty(name))
                return new ObjectResult(new { Status = 400, Value = "Pizza name can't be empty" });

            var pizza = new Pizza() { Name = name };

            try
            {
                return pizzaToppingService.DeleteToppings(pizza, toppings);
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }
    }
}
