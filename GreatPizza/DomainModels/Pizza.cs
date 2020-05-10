using System.Collections.Generic;

namespace GreatPizza.DomainModels
{
    public class Pizza
    {
        public string Name { get; set; }
        public List<Topping> Toppings { get; set; } = new List<Topping>();
    }
}
