namespace ConsoleApplication {

public class Human { 
    public int strength = 3; 
    public int intelligence = 3;

    public int health = 100;

    public int dexterity = 3;

    public string name;
    
    public Human(string newName) {
        name = newName;
        }
    public Human (string _name, int str, int intell, int heal, int dex) {
        strength = str;
        intelligence = intell;
        health = heal;
        dexterity = dex;
        name = _name;
        
        }
    public void Attack(Human opponent) //opponent = Human taking damage
        {
        opponent.health-=strength *5;
        if (opponent.health < 0) {
            opponent.health = 0;
        }
        }
    }   
}