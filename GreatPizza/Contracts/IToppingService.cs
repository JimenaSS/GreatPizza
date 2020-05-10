using GreatPizza.DomainModels;
using System.Collections.Generic;

namespace GreatPizza.Contracts
{
    /// <summary>
    /// Handles functionality related with Topping items. Works with Topping model.
    /// </summary>
    public interface IToppingService
    {
        /// <summary>
        /// Retrieves all Topping stored items.
        /// </summary>
        /// <returns>List with Topping items.</returns>
        List<Topping> GetAll();

        /// <summary>
        /// Adds topping item.
        /// </summary>
        /// <param name="topping"></param>
        /// <returns>The stored item.</returns>
        void Add(Topping topping);

        /// <summary>
        /// Deletes topping item.
        /// </summary>
        /// <param name="topping"></param>
        void Delete(Topping topping);
    }
}
