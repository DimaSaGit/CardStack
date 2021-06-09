using System.Collections.Generic;

namespace CardStack
{
    public interface IDeck
    {
        void CreateDeck(string name);

        void DeleteDeck(string name);

        List<string> GetAllDecksNames();

        void ShuffleDeck(string name, bool handEmulate);

        Deck GetDeck(string name);
    }
}
