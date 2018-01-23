using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lost_in_woods.Models;
 
namespace lost_in_woods.Factory
{
    public class HikeFactory : IFactory<Hike>
    {
        private string connectionString;
        public HikeFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=lost_in_woodsdb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Hike hike)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails(name, length, elevation, longitude, latitude, description) VALUES (@Name, @Length, @Elevation, @Longitude, @Latitude, @Description)";
                dbConnection.Open();
                dbConnection.Execute(query, hike);
            }
        }
        public IEnumerable<Hike> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Hike>("SELECT * FROM trails");
            }
        }
        public Hike FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Hike>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}