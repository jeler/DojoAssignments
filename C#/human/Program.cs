using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Jenny = new Human("Jenny",5 ,10 , 15, 500);
            Human Ozzy = new Human("Ozzy", 10, 10, 500, 20);
            // Console.WriteLine(myHuman.name);
            Ozzy.Attack(Jenny);
            Console.WriteLine("Strength of my human is" + Jenny.strength);
            Console.WriteLine("Health is" + " "+ Jenny.health);
            Console.WriteLine("Name is" + " " + Jenny.name);
        }
    }
}
