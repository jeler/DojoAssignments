using System.Collections.Generic;
using System.Data;
using System.Linq;
using dojo_league.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace dojo_league.Factory {
    public class NinjaFactory : IFactory<Dojo> {
        private string connectionString;
        public NinjaFactory () {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=dojo_leaguedb;SslMode=None";
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection (connectionString);
            }
        }

        public void Add (Ninja ninja) {
            using (IDbConnection dbConnection = Connection) {
                System.Console.WriteLine("+++++++++" + ninja.dojos_id);
                dbConnection.Open ();
                if(ninja.dojos_id == 0) {
                    string query = "INSERT INTO ninjas(name, level, description) VALUES (@name, @level, @description)";
                    dbConnection.Execute (query, ninja);     
                }
                else {
                    string query = "INSERT INTO ninjas(name, level, description, dojos_id) VALUES (@name, @level, @description, @dojos_id)";
                    dbConnection.Execute (query, ninja);
                }
            }
        }
        public IEnumerable<Ninja> FindAll () {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open ();
                return dbConnection.Query<Ninja> ("SELECT ninjas.name, dojos.name  AS dojoname, dojos.id AS dojos_id, ninjas.id AS id FROM ninjas JOIN dojos on ninjas.dojos_id = dojos.id");
            }
        }
        public IEnumerable<Ninja> NinjasForDojoById (int id) {
            using (IDbConnection dbConnection = Connection) {
                var query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojos_id WHERE dojos.id = ninjas.dojos_id AND dojos.id = {id}";
                dbConnection.Open ();
                var myNinjas = dbConnection.Query<Ninja, Dojo, Ninja> (query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
                return myNinjas;
            }
        }
    }
}