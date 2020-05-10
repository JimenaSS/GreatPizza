using System;
using System.Collections.Generic;
using GreatPizza.Contracts;
using GreatPizza.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace GreatPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private IToppingService toppingService;

        public ToppingController(IToppingService toppingService)
        {
            this.toppingService = toppingService;
        }

        // GET api/topping
        [HttpGet]
        public ActionResult<List<Topping>> Get()
        {
            try
            {
                return toppingService.GetAll();
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }

        // POST api/topping
        [HttpPost]
        public IActionResult Post([FromBody] Topping topping)
        {
            if (string.IsNullOrEmpty(topping.Name))
                return new ObjectResult(new { Status = 400, Value = "Topping name can't be empty" });

            try
            {
                toppingService.Add(topping);
                return new ObjectResult(new { Status = 200, Value = string.Format("Topping {0} created", topping.Name) });
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }

        // DELETE api/topping/[name]
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new ObjectResult(new { Status = 400, Value = "Topping name can't be empty" });

            try
            {
                toppingService.Delete(new Topping() { Name = name });
                return new ObjectResult(new { Status = 200, Value = string.Format("Topping {0} deleted", name) });
            }
            catch (Exception exception)
            {
                return new ObjectResult(new { Status = 500, Value = exception.Message });
            }
        }
    }
}
