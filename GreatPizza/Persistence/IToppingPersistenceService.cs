using GreatPizza.Persistence.Entities;
using System.Collections.Generic;

namespace GreatPizza.Persistence
{
    /// <summary>
    /// Responsible of Topping entity persistence methods. Handles ToppingEntity objects.
    /// </summary>
    public interface IToppingPersistenceService
    {
        /// <summary>
        /// Retrieves all Topping stored entities.
        /// </summary>
        /// <returns>List with Topping entities.</returns>
        List<ToppingEntity> GetAll();

        /// <summary>
        /// Retrieves one Topping stored entity using its name as reference.
        /// </summary>
        /// <returns>One Topping entity.</returns>
        ToppingEntity GetByName(string name);

        /// <summary>
        /// Adds topping entity.
        /// </summary>
        /// <param name="topping"></param>
        void Add(ToppingEntity topping);

        /// <summary>
        /// Deletes topping entity.
        /// </summary>
        /// <param name="topping"></param>
        void Delete(ToppingEntity topping);
    }
}
