using GreatPizza.DomainModels;
using System.Collections.Generic;

namespace GreatPizza.Contracts
{
    /// <summary>
    /// Handles functionality related with Pizza items. Works with Pizza model.
    /// </summary>
    public interface IPizzaToppingService
    {
        /// <summary>
        /// Adds one Topping item to list in Pizza.
        /// </summary>
        /// <param name="Pizza"></param>
        /// <returns>Updated Pizza with stored Topping items.</returns>
        Pizza AddToppings(Pizza pizza, List<Topping> toppings);

        /// <summary>
        /// Adds one Topping item to list in Pizza.
        /// </summary>
        /// <param name="Pizza"></param>
        /// <returns>List of stored Topping items from pizza.</returns>
        List<Topping> GetPizzaToppings(Pizza pizza);

        /// <summary>
        /// Deletes one Topping item from list in Pizza.
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns>Updated Pizza with stored Topping items.</returns>
        Pizza DeleteToppings(Pizza pizza, List<Topping> toppings);
    }
}
