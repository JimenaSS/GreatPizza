using GreatPizza.DomainModels;

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
        Pizza AddTopping(Pizza pizza, Topping topping);

        /// <summary>
        /// Deletes one Topping item from list in Pizza.
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns>Updated Pizza with stored Topping items.</returns>
        Pizza DeleteTopping(Pizza pizza, Topping topping);
    }
}
