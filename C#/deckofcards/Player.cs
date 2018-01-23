using System;
using System.Collections.Generic;

namespace deckofcards {
    public class Player {
    
    public List<Card> hand = new List<Card> ();
    // foreach(object thing in hand) {
    //     Console.WriteLine("This is {0}", thing);
    // }

    public string name;

    public Player(string newName) {
        name = newName;
        // Console.WriteLine("Name is {0}", newName);
        }

    public Card Draw(Deck newDeck) 
        {
            Card newcard = newDeck.Deal();
            hand.Add(newcard);
            Console.WriteLine("Card is DRAW {0} suit and {1} type", newcard.StringVal, newcard.Suit);
            return newcard;

        }
    public Card Discard(int index)
        {
            if (index > hand.Count) {
                Console.WriteLine("This index is out of range!");
                return null;
            }
            else {
                Card handcard = hand[index];
                Console.WriteLine("Handcard is this {0} and {1}", handcard.StringVal, handcard.Suit);
                return handcard;
            }
        }
    }
}
