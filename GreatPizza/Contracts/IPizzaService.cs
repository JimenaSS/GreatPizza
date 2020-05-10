using GreatPizza.DomainModels;
using System.Collections.Generic;

namespace GreatPizza.Contracts
{
    /// <summary>
    /// Handles functionality related with Pizza items. Works with Pizza model.
    /// </summary>
    public interface IPizzaService
    {
        /// <summary>
        /// Retrieves all Pizza stored items.
        /// </summary>
        /// <returns>List with Pizza items.</returns>
        List<Pizza> GetAll();

        /// <summary>
        /// Retrieves one specific pizza using its name as reference.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>One Pizza item.</returns>
        Pizza GetByName(string name);

        /// <summary>
        /// Adds Pizza item.
        /// </summary>
        /// <param name="Pizza"></param>
        void Add(Pizza pizza);

        /// <summary>
        /// Deletes pizza item.
        /// </summary>
        /// <param name="pizza"></param>
        void Delete(Pizza pizza);
    }
}
