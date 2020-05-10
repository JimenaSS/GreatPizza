using GreatPizza.Persistence.Entities;
using System.Collections.Generic;

namespace GreatPizza.Persistence
{
    /// <summary>
    /// Responsible of Pizza entity persistence methods. Handles PizzaEntity objects.
    /// </summary>
    interface IPizzaPersistenceService
    {
        /// <summary>
        /// Retrieves all Pizza stored entities.
        /// </summary>
        /// <returns>List with Pizza entities.</returns>
        List<PizzaEntity> GetAll();

        /// <summary>
        /// Retrieves all Pizza stored entities.
        /// </summary>
        /// <returns>One Pizza entity.</returns>
        PizzaEntity GetByName(string name);

        /// <summary>
        /// Adds Pizza entity.
        /// </summary>
        /// <param name="Pizza"></param>
        void Add(PizzaEntity pizza);

        /// <summary>
        /// Update Pizza entity.
        /// </summary>
        /// <param name="Pizza"></param>
        void Update(PizzaEntity pizza);

        /// <summary>
        /// Deletes Pizza entity.
        /// </summary>
        /// <param name="Pizza"></param>
        void Delete(PizzaEntity pizza);
    }
}
