using System;
using System.Collections.Generic;
using System.Linq;

namespace CardStack
{
    public class Model:IDeck
    {
        private Dictionary<string,Deck> stackOfDecks;

        public Model()
        {
            stackOfDecks = new Dictionary<string, Deck>();
        }

        public void CreateDeck(string name)
        {
            stackOfDecks.Add(name, new Deck(name));
        }

        public void DeleteDeck(string name)
        {
            stackOfDecks.Remove(name);
        }

        public List<string> GetAllDecksNames()
        {
            return stackOfDecks.Keys.ToList();
        }

        public Deck GetDeck(string name)
        {
            return stackOfDecks[name];
        }

        public void ShuffleDeck(string name, bool handEmulate)
        {
            if (handEmulate)
                stackOfDecks[name] = stackOfDecks[name].HandShuffleDeck();
            else
                stackOfDecks[name] = stackOfDecks[name].ShuffleDeck2();
        }

        public string GetString(string name)
        {
            return stackOfDecks[name].ConvertDeckToString();
        }
    }
}
