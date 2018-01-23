using System.Collections.Generic;
using System;

namespace deckofcards {

    public class Deck {
        List<Card> cards = new List<Card> ();
        public Deck () {
            string[] StrVal = new string[13] {
                "Ace",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "Jack",
                "Queen",
                "King"
            };

            string[] SuitVal = new string[4] { "Clubs", "Spades", "Hearts", "Diamonds" };

            int[] ValueVal = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            Console.WriteLine(SuitVal.Length);
            Console.WriteLine(StrVal.Length);

            for (int i = 0; i < SuitVal.Length; i++) {
                for (int x = 0; x < StrVal.Length; x++) {
                    Card thisCard = new Card (StrVal[x], SuitVal[i], ValueVal[i]);
                    cards.Add (thisCard);
                    Console.WriteLine("This card is {0}, {1}",  StrVal[x], SuitVal[i]);
                }
            }
        }
        public Card Deal()  // Card needed for return statement
        {
            Card topCard = cards[0];
            cards.Remove (topCard);
            Console.WriteLine("This is DEAL suit {0} and this is value {1}",topCard.StringVal, topCard.Suit);
            return topCard;
 
        }
        public void Shuffle() {
            Random rand = new Random();
            for(int i = 0; i < cards.Count; i++) {
                int randIndex = rand.Next(i, cards.Count);  // Get second random index
                Card tempCard = cards[i];
                cards[i] = cards[randIndex];
                cards[randIndex] = tempCard;
            }
        }
        public void Reset() {
        cards = new List<Card> (); 
        string[] StrVal = new string[13] {
                "Ace",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "Jack",
                "Queen",
                "King"
            };
            string[] SuitVal = new string[4] { "Clubs", "Spades", "Hearts", "Diamonds" };
            int[] ValueVal = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };           
            for (int i = 0; i < SuitVal.Length; i++) {
                for (int x = 0; x < StrVal.Length; x++) {
                    Card thisCard = new Card (StrVal[x], SuitVal[i], ValueVal[i]);
                    cards.Add (thisCard);     
                }
            }
        }
    }
}