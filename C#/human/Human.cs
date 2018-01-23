using System;

namespace ConsoleApplication {

    public class Human {
        public int strength = 3;
        public int intelligence = 3;

        public int health = 100;

        public int dexterity = 3;

        public string name;

        public Human (string newName) {
            name = newName;
        }
        public Human (string _name, int str, int intell, int heal, int dex) {
            strength = str;
            intelligence = intell;
            health = heal;
            dexterity = dex;
            name = _name;

        }
        public void Attack (Human opponent) //opponent = Human taking damage
        {
            opponent.health -= strength * 5;
            if (opponent.health < 0) {
                opponent.health = 0;
            }
        }
    }
    public class Wizard : Human {
        public Wizard(string _name, int str, int intell, int heal, int dex): base(_name, str, intell,heal,dex) {

        }

        public Wizard (string newName): base (newName) {
            this.health = 50;
            this.intelligence = 25;
        }
        public void Heal() {
            health += 10 * intelligence;

        }

        public void Fireball(Human opponent) {
            System.Random rand = new System.Random();
            int randint = rand.Next(20, 50);
            System.Console.WriteLine("Random int is {0}", randint);
            opponent.health -=randint;
            if (opponent.health < 0) {
                opponent.health = 0;
            }
        }
    }

    public class Ninja : Human {
        public Ninja(string _name, int str, int intell, int heal, int dex): base(_name, str, intell,heal,dex) {

        }
        
        public Ninja(string newName): base(newName) {
            this.dexterity = 175;

        }

        public void Steal(Human opponent) {
            health+=10;
        }

        public void Get_Away(Human opponent) {
            health-=15;
        }
    }
    public class Samurai : Human {

        static int count = 0;
        public Samurai(string _name, int str, int intell, int heal, int dex): base(_name, str, intell,heal,dex) {
            count++;

        }
        
        public Samurai(string newName): base(newName) {
            this.health = 200;
            count++;

        }
        public void Death_Blow(Human opponent) {
            if(opponent.health < 50) {
                opponent.health = 0;
            }
        }
        public void Meditate() {
            this.health = 200; 
        }

        public static void Count() {
            System.Console.WriteLine("Samurai count is {0}", count);
        }
    }
}