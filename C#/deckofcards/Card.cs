using System;
using System.Collections.Generic;


namespace deckofcards
{
    public class Card 
    {
        // What happens when we create a card object
        public string StringVal;

        public string Suit;

        public int Value;

        public Card(string sv, string s, int v)
        {
            StringVal = sv;
            Suit = s;
            Value = v;

        }
    }
}