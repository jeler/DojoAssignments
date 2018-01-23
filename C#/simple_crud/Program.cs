using System;
using DbConnection;

namespace simple_crud
{
    class Program
    {

        public static void Read() {
            string query = "SELECT * FROM users";
            var AllUsers = DbConnector.Query(query);

            foreach(var user in AllUsers) {
                Console.WriteLine("This is {0} {1}, and their favorite number is {2}", user["FirstName"], user["LastName"], user["FavoriteNumber"]);
                // Console.WriteLine($"{user["FirstName"]} {user["LastName"]}, {user["FavoriteNumber"]}");
            }
        }

        public static void Create() {
            System.Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            string fString = '"' + firstName + '"';
            System.Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            string lString = '"' + lastName + '"';
            System.Console.WriteLine("Enter lucky number");
            string luckyNum = Console.ReadLine();
            // string nString = '"' + luckyNum + '"';
            string insert = $"INSERT INTO users (FirstName, LastName, FavoriteNumber) VALUES ({fString}, {lString}, {luckyNum})";
            DbConnector.Execute(insert);
            Read();
        }

        public static void Update() {
            Console.WriteLine("Enter user_id");
            string id = Console.ReadLine();
            System.Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            string fString = '"' + firstName + '"';
            System.Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            string lString = '"' + lastName + '"';
            System.Console.WriteLine("Enter lucky number");
            string luckyNum = Console.ReadLine();
            string nString = '"' + luckyNum + '"';
            // Why do you not need nString for this one?
            // string update = $"UPDATE users SET (FirstName, LastName, FavoriteNumber) = ({fString}), ({lString}), ({nString}) WHERE id = ({id})";
            string update = $"UPDATE users SET FirstName = {fString}, LastName = {lString}, FavoriteNumber = {nString} WHERE id = {id}";
            DbConnector.Execute(update);
        }
        static void Main(string[] args)
        {
            // Read();
            // Create();
            Update();

        }
    }
}
