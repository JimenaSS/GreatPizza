using GreatPizza.DomainModels;

namespace GreatPizza.Contracts
{
    /// <summary>
    /// Handles functionality related with Pizza items. Works with Pizza model.
    /// </summary>
    interface IPizzaToppingService
    {
        /// <summary>
        /// Adds one Topping item to list in Pizza.
        /// </summary>
        /// <param name="Pizza"></param>
        void AddTopping(Pizza pizza, Topping topping);

        /// <summary>
        /// Deletes one Topping item from list in Pizza.
        /// </summary>
        /// <param name="pizza"></param>
        void DeleteTopping(Pizza pizza, Topping topping);
    }
}
