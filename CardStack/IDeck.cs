using System.Collections.Generic;

namespace CardStack
{
    /*
     * Интерфейс описывающий методы
     * •	Создать именованную колоду карт (колода создаётся упорядоченной)
     * •	Удалить именованную колоду
     * •	Получить список названий колод
     * •	Перетасовать колоду
     * •	Получить колоду по имени (в её текущем упорядоченном/перетасованном состоянии)
     */
    public interface IDeck
    {
        void CreateDeck(string name);

        void DeleteDeck(string name);

        List<string> GetAllDecksNames();

        void ShuffleDeck(string name, bool handEmulate);

        Deck GetDeck(string name);
    }
}
