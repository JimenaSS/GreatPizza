using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GreatPizza.Persistence.Entities;
using Microsoft.Extensions.Configuration;

namespace GreatPizza.Persistence
{
    /// <summary>
    /// Basic repository class that uses Dapper to map results from queries into Pizza persistence entity.
    /// </summary>
    public class PizzaRepository : IPizzaPersistenceService
    {
        private IDbConnection databaseConnection;

        /// <summary>
        /// Initialices sql connection.
        /// </summary>
        /// <param name="configuration"></param>
        public PizzaRepository(IConfiguration configuration)
        {
            /* Get config information for connection */
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            databaseConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Adds Pizza entity.
        /// </summary>
        /// <param name="pizza"></param>
        public void Add(PizzaEntity pizza)
        {
            /* Executes query to insert Pizza informaiton to Pizza schema */
            databaseConnection.Query<PizzaEntity>("INSERT INTO Pizza (Name) values (@Name)", new { Name = pizza.Name });

            /* Inserts pizza topping items to PizzaTopping relational schema */
            foreach (var topping in pizza.Toppings)
            {
                databaseConnection.Query<PizzaEntity>(
                    "INSERT INTO PizzaTopping (PizzaName, ToppingName) values (@PizzaName, @ToppingName)",
                    new { PizzaName = pizza.Name, ToppingName = topping.Name}
                );
            }
        }

        /// <summary>
        /// Deletes Pizza entity.
        /// </summary>
        /// <param name="Pizza"></param>
        public void Delete(PizzaEntity pizza)
        {
            databaseConnection.Query<PizzaEntity>(
                "DELETE FROM Pizza WHERE Name = @Name; DELETE FROM PizzaTopping WHERE PizzaName = @Name;", new { Name = pizza.Name }
                );
        }

        /// <summary>
        /// Retrieves all Pizza stored entities.
        /// </summary>
        /// <returns>List with Pizza entities.</returns>
        public List<PizzaEntity> GetAll()
        {
            /* Retrieved data from query execution will be handled by this dictionary to avoid duplicating entries in dictionary */
            var pizzaEntitiesLookup = new Dictionary<string, PizzaEntity>();

            var query = @"
SELECT p.Name, pt.ToppingName as Name
FROM Pizza p
INNER JOIN PizzaTopping pt
    ON p.Name = pt.PizzaName";

            List<PizzaEntity> pizzaEntities = databaseConnection.Query<PizzaEntity, ToppingEntity, PizzaEntity>(
                query,
                (pizzaEntity, pizzaTopping) =>
                {
                    /* Current variable will be used in case an entry with the same name already exists in dictionary */
                    PizzaEntity current;

                    if (!pizzaEntitiesLookup.TryGetValue(pizzaEntity.Name, out current))
                        pizzaEntitiesLookup.Add(pizzaEntity.Name, current = pizzaEntity);
                    if (current.Toppings == null)
                        current.Toppings = new List<ToppingEntity>();
                    current.Toppings.Add(pizzaTopping);  /* Add topping entity to current pizza */

                    return current;
                },
                splitOn: "Name")
                .ToList();

            return pizzaEntitiesLookup.Values.ToList();
        }

        /// <summary>
        /// Retrieves one Pizza stored entity using its name as reference.
        /// </summary>
        /// <returns>One Pizza entity.</returns>
        public PizzaEntity GetByName(string name)
        {
            return GetAll().Where(pizzaEntity => pizzaEntity.Name == name).SingleOrDefault();
        }

        /// <summary>
        /// Update Topping entities in stored Pizza entity.
        /// </summary>
        /// <param name="Pizza"></param>
        public void Update(PizzaEntity pizza)
        {
            /* Delete all current entries from PizzaTopping for an specific pizza item */
            databaseConnection.Query<PizzaEntity>(
                "DELETE FROM PizzaTopping WHERE PizzaName = @Name;",
                new { Name = pizza.Name }
                );

            foreach (var topping in pizza.Toppings)
            {
                databaseConnection.Query<PizzaEntity>(
                    "INSERT INTO PizzaTopping (PizzaName, ToppingName) values (@PizzaName, @ToppingName)",
                    new { PizzaName = pizza.Name, ToppingName = topping.Name }
                );
            }
        }
    }
}
