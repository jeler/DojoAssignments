using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Jenny = new Human("Jenny",5 ,10 , 25, 500);
            Human Ozzy = new Human("Ozzy", 10, 10, 500, 20);
            Wizard Brad = new Wizard("Brad");
            Ninja Allyson = new Ninja("Allyson");
            Samurai Jessica = new Samurai("Jessica");
            // Console.WriteLine(myHuman.name);
            // Ozzy.Attack(Jenny);
            // Console.WriteLine("Strength of my human is" + Jenny.strength);
            // Console.WriteLine("Name is" + " " + Jenny.name);
            // Console.WriteLine("Brad's health is {0} and Brad's intell is {1}", Brad.health, Brad.intelligence);
            // Brad.Heal();
            // Console.WriteLine("Brad's health is now {0}", Brad.health);
            // Console.WriteLine("Jenny's health is {0}", Jenny.health);
            // Brad.Fireball(Jenny);
            // Console.WriteLine("Jenny's health is {0}", Jenny.health);      
            // Console.WriteLine("Allyson's health is {0}", Allyson.health);      
            // Allyson.Steal(Jenny);
            // Console.WriteLine("Allyson's health is {0}", Allyson.health);
            // Allyson.Get_Away(Jenny);                  
            // Console.WriteLine("Allyson's health is {0}", Allyson.health);
            Console.WriteLine("Jenny's health is {0}", Jenny.health);            
            Jessica.Death_Blow(Jenny);
            Console.WriteLine("Jenny's health is {0}", Jenny.health);
            Samurai.Count();
            
                        

        }
    }
}
