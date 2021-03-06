using System;
namespace CardStack
{
    /*
     * Класс Card
     * Содержит поля масть и достоинство
     * Оба поля принимают значения из соответствующих перечислений
     */
    public enum Suits
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }

    public enum Values
    {
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        Jack,
        Queen,
        King,
        Ace
    }
    public class Card
    {

        public Suits suit;
        public Values value;

        public Card()
        {
            
        }
        public Card(Suits suit, Values value)
        {
            this.suit = suit;
            this.value = value;
        }
    }
}
