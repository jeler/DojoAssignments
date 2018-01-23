using System;

namespace deckofcards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            Player Jenny = new Player("Jenny");
            newDeck.Shuffle();
            Jenny.Draw(newDeck);
            Jenny.Draw(newDeck);
            Jenny.Draw(newDeck);
            foreach (var thing in Jenny.hand) {
                Console.WriteLine("The card is {0} and {1}", thing.Suit, thing.StringVal);
            }
            Jenny.Discard(1);
            // newDeck.
        }
    }
}
