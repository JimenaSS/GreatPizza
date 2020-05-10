using System.Collections.Generic;

namespace GreatPizza.Persistence.Entities
{
    public class PizzaEntity
    {
        public string Name { get; set; }
        public List<ToppingEntity> Toppings { get; set; }
    }
}
