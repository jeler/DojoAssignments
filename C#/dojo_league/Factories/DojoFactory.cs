using System.Collections.Generic;
using System.Data;
using System.Linq;
using dojo_league.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace dojo_league.Factory {
    public class DojoFactory : IFactory<Dojo> {
        private string connectionString;
        public DojoFactory () {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojo_leaguedb;SslMode=None";
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection (connectionString);
            }
        }

        public void Add (Dojo dojo) {
            using (IDbConnection dbConnection = Connection) {
                string query = "INSERT INTO dojos(name, location, information) VALUES (@name, @location, @information)";
                dbConnection.Open ();
                dbConnection.Execute (query, dojo);
            }
        }
        public IEnumerable<Dojo> FindAll () {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open ();
                return dbConnection.Query<Dojo> ("SELECT * FROM dojos");
            }
        }
        public Dojo FindById (long id) {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open ();
                var query =
                    @"
                            SELECT * FROM dojos WHERE id = @Id;
                            SELECT * FROM ninjas WHERE dojos_id = @Id;
                            ";

                using (var multi = dbConnection.QueryMultiple (query, new { Id = id })) {
                    var dojo = multi.Read<Dojo> ().Single ();
                    dojo.ninjas = multi.Read<Ninja> ().ToList ();
                    return dojo;
                }
            }
        }
    }
}