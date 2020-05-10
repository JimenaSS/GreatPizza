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
    /// Basic repository class that uses Dapper to map results from queries into Topping persistence entity.
    /// </summary>
    public class ToppingRepository : IToppingPersistenceService
    {
        private IDbConnection databaseConnection;

        /// <summary>
        /// Initialices sql connection.
        /// </summary>
        /// <param name="configuration"></param>
        public ToppingRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            databaseConnection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Adds topping entity.
        /// </summary>
        /// <param name="topping"></param>
        public void Add(ToppingEntity topping)
        {
            databaseConnection.Query<ToppingEntity>("INSERT INTO Topping (Name) VALUES (@Name)", new { Name = topping.Name }).SingleOrDefault();
        }

        /// <summary>
        /// Deletes topping entity.
        /// </summary>
        /// <param name="topping"></param>
        public void Delete(ToppingEntity topping)
        {
            databaseConnection.Query<ToppingEntity>("DELETE FROM Topping WHERE Name = @Name", new { Name = topping.Name });
        }

        /// <summary>
        /// Retrieves all Topping stored entities.
        /// </summary>
        /// <returns>List with Topping entities.</returns>
        public List<ToppingEntity> GetAll()
        {
            return databaseConnection.Query<ToppingEntity>("SELECT * FROM Topping").ToList();
        }

        /// <summary>
        /// Retrieves one Topping stored entity using its name as reference.
        /// </summary>
        /// <returns>One Topping entity.</returns>
        public ToppingEntity GetByName(string name)
        {
            return databaseConnection.Query<ToppingEntity>("SELECT Name FROM Topping WHERE Name = @Name", new { Name = name }).SingleOrDefault();
        }
    }
}
