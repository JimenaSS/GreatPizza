using GreatPizza.Contracts;
using GreatPizza.DomainModels;
using GreatPizza.Persistence;
using GreatPizza.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GreatPizza.Services
{
    /// <summary>
    /// Handles functionality related with Topping items. Works with Topping model using an instance of
    /// IToppingService to store data.
    /// </summary>
    public class ToppingService : IToppingService
    {
        IToppingPersistenceService toppingPersistenceService;

        /// <param name="toppingPersistenceService"></param>
        public ToppingService(IToppingPersistenceService toppingPersistenceService)
        {
            this.toppingPersistenceService = toppingPersistenceService;
        }

        /// <summary>
        /// Adds topping item converting toping domain model into a persisting entity.
        /// </summary>
        /// <param name="topping"></param>
        public void Add(Topping topping)
        {
            toppingPersistenceService.Add(new ToppingEntity() { Name = topping.Name });
        }

        /// <summary>
        /// Deletes topping item converting toping domain model into a persisting entity.
        /// </summary>
        /// <param name="topping"></param>
        public void Delete(Topping topping)
        {
            var toppingEntity = new ToppingEntity() { Name = topping.Name };
            toppingPersistenceService.Delete(toppingEntity);
        }

        /// <summary>
        /// Retrieves all Topping stored items.
        /// </summary>
        /// <returns>List of stored toppings</returns>
        public List<Topping> GetAll()
        {
            return toppingPersistenceService.GetAll()
                .Select(x => new Topping() { Name = x.Name })
                .ToList();
        }

        /// <summary>
        /// Retrieves one Topping stored item using its name as reference.
        /// </summary>
        /// <returns>Stored topping item</returns>
        public Topping GetByName(string name)
        {
            ToppingEntity toppingEntity = toppingPersistenceService.GetByName(name);

            if (toppingEntity == null)
                return null;

            return new Topping() { Name = toppingEntity.Name };
        }
    }
}
