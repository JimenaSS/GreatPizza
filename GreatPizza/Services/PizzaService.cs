using GreatPizza.Contracts;
using GreatPizza.DomainModels;
using GreatPizza.Persistence;
using GreatPizza.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GreatPizza.Services
{
    public class PizzaService : IPizzaService, IPizzaToppingService
    {
        IPizzaPersistenceService pizzaRepository;

        public PizzaService(IPizzaPersistenceService pizzaRepository)
        {
            this.pizzaRepository = pizzaRepository;
        }

        /// <summary>
        /// Adds Pizza item converting it into a Pizza entity to work with pizza
        /// repository.
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns>Pizza item converted from returned pizza entity.</returns>
        public void Add(Pizza pizza)
        {
            var toppingEntities = pizza.Toppings != null
                ? pizza.Toppings.Select(toppingModel => new ToppingEntity() { Name = toppingModel.Name }).ToList()
                : new List<ToppingEntity>();
            pizzaRepository.Add(new PizzaEntity() { Name = pizza.Name, Toppings = toppingEntities });
        }

        /// <summary>
        /// Deletes pizza item using its name to build Pizza entity.
        /// </summary>
        /// <param name="pizza"></param>
        public void Delete(Pizza pizza)
        {
            pizzaRepository.Delete(new PizzaEntity() { Name = pizza.Name});
        }

        /// <summary>
        /// Retrieves all Pizza stored items converting from Pizza entities to Pizza items.
        /// </summary>
        /// <returns>List with Pizza items.</returns>
        public List<Pizza> GetAll()
        {
            var pizzaEntities = pizzaRepository.GetAll();
            return pizzaEntities.Select(
                pizzaEntity => new Pizza() {
                    Name = pizzaEntity.Name,
                    Toppings = pizzaEntity.Toppings.Select(toppingEntity => new Topping() { Name = toppingEntity.Name }).ToList()
                }
                ).ToList();
        }

        /// <summary>
        /// Retrieves one specific pizza using its name as reference.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>One Pizza item.</returns>
        public Pizza GetByName(string name)
        {
            var pizzaEntity = pizzaRepository.GetByName(name);

            return new Pizza() {
                Name = pizzaEntity.Name,
                Toppings = pizzaEntity.Toppings.Select(toppingEntity => new Topping() { Name = toppingEntity.Name }).ToList()
            };
        }

        /// <summary>
        /// Adds one Topping item to list in Pizza verifying first if topping name is
        /// valid and updating entity using pizza repository.
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="topping"></param>
        /// <returns>Updated Pizza with stored Topping items.</returns>
        public Pizza AddTopping(Pizza pizza, Topping topping)
        {
            if (!string.IsNullOrEmpty(topping.Name))
                pizza.Toppings.Add(topping);

            var toppingEntities = pizza.Toppings.Select(toppingModel => new ToppingEntity() { Name = toppingModel.Name }).ToList();
            pizzaRepository.Update(new PizzaEntity() { Name = pizza.Name, Toppings = toppingEntities });

            return pizza;
        }

        /// <summary>
        /// Deletes one Topping item from list in Pizza verifying first if topping name is
        /// valid and topping exists in pizza toppings list and updating entity using
        /// pizza repository.
        /// </summary>
        /// <param name="pizza"></param>
        /// <param name="topping"></param>
        /// <returns>Updated Pizza with stored Topping items.</returns>
        public Pizza DeleteTopping(Pizza pizza, Topping topping)
        {
            if (!string.IsNullOrEmpty(topping.Name) && pizza.Toppings.Contains(topping))
                pizza.Toppings.Remove(topping);

            var toppingEntities = pizza.Toppings.Select(toppingModel => new ToppingEntity() { Name = toppingModel.Name }).ToList();
            pizzaRepository.Update(new PizzaEntity() { Name = pizza.Name, Toppings = toppingEntities });

            return pizza;
        }
    }
}
